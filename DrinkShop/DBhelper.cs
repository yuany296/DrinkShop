using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DrinkShop
{
    internal class DBhelper
    {
        private static string connString = "User Id=sys;Password=123456;Data Source=localhost:1521/xe;DBA Privilege=SYSDBA";

        private OracleConnection GetConnection()
        {
            return new OracleConnection(connString);
        }

        // 登录验证
        public string LoginIn(string phone, string password)
        {
            // 添加输入验证
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 11)
            {
                return "手机号必须是11位数字";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return "密码不能为空";
            }

            string returnString = "";
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. 先验证手机号是否存在
                    string chkphone = "SELECT count(*) FROM Users WHERE phone = :phone";
                    using (OracleCommand checkPhoneCmd = new OracleCommand(chkphone, conn))
                    {
                        checkPhoneCmd.BindByName = true;
                        checkPhoneCmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                        int phoneCount = Convert.ToInt32(checkPhoneCmd.ExecuteScalar());

                        if (phoneCount == 0)
                        {
                            return "用户不存在，快去注册吧";
                        }
                    }

                    // 2. 验证密码
                    string sql2 = "SELECT count(*) FROM Users WHERE phone = :phone AND password = :password";
                    using (OracleCommand cmd = new OracleCommand(sql2, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                        cmd.Parameters.Add("password", OracleDbType.Varchar2, 50).Value = password;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        returnString = (count > 0) ? "登录成功" : "密码错误";
                    }
                }
                catch (Exception ex)
                {
                    returnString = $"登录失败: {ex.Message}";
                }
            }
            return returnString;
        }

        // 注册
        public (bool Success, string Message) SignUp(string phone, string name, string address, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phone) || phone.Length != 11) return (false, "手机号必须是11位数字");
                if (string.IsNullOrWhiteSpace(name)) return (false, "姓名不能为空");
                if (string.IsNullOrWhiteSpace(password)) return (false, "密码不能为空");

                if (CheckPhoneExists(phone)) return (false, "该手机号已注册，请直接登录");

                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (phone, name, address, password) VALUES (:phone, :name, :address, :password)";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                        cmd.Parameters.Add("name", OracleDbType.Varchar2, 30).Value = name;
                        cmd.Parameters.Add("address", OracleDbType.Varchar2, 50).Value = string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address;
                        cmd.Parameters.Add("password", OracleDbType.Varchar2, 50).Value = password;

                        return cmd.ExecuteNonQuery() > 0 ? (true, "注册成功！") : (false, "注册失败");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, $"错误: {ex.Message}");
            }
        }

        private bool CheckPhoneExists(string phone)
        {
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE phone = :phone";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = true;
                    cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // 获取饮品类型列表
        public List<string> GetDrinkType()
        {
            List<string> types = new List<string>() { "全部" };
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT type FROM Drinks";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0)) types.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"获取类型失败: {ex.Message}");
                }
            }
            return types;
        }

        // 获取对应type的Drinks
        public DataTable GetDrinks(string drinkType = "全部")
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql;

                    // 根据类型选择 SQL 语句
                    if (drinkType == "全部")
                    {
                        sql = "SELECT drink_id, name, type, price, stock FROM Drinks ORDER BY type, name";
                    }
                    else
                    {
                        sql = "SELECT drink_id, name, type, price, stock FROM Drinks WHERE type = :type ORDER BY name";
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true; // 确保参数名绑定正确

                        if (drinkType != "全部")
                        {
                            cmd.Parameters.Add("type", OracleDbType.Varchar2).Value = drinkType;
                        }

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    // 设置列名（用于 DataGridView 自动显示中文表头）
                    if (dt.Columns.Count > 0)
                    {
                        dt.Columns["drink_id"].ColumnName = "饮品ID";
                        dt.Columns["name"].ColumnName = "饮品名称";
                        dt.Columns["type"].ColumnName = "类型";
                        dt.Columns["price"].ColumnName = "价格";
                        dt.Columns["stock"].ColumnName = "库存";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"获取饮品列表失败: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        // 下单支付逻辑（带事务处理）
        public (bool Success, string Message) PlaceOrder(string phone, List<CartItem> cartItems, decimal totalAmount)
        {
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                using (OracleTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. 插入订单主表
                        int newOrderId = 0;
                        string orderSql = "INSERT INTO Orders (order_id, phone, order_time, total_amount) " +
                                         "VALUES (seq_order_id.nextval, :phone, SYSTIMESTAMP, :total_amount) " +
                                         "RETURNING order_id INTO :order_id_out";

                        using (OracleCommand orderCmd = new OracleCommand(orderSql, conn))
                        {
                            orderCmd.Transaction = transaction;
                            orderCmd.BindByName = true;
                            orderCmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            orderCmd.Parameters.Add("total_amount", OracleDbType.Decimal).Value = totalAmount;

                            OracleParameter orderIdParam = new OracleParameter("order_id_out", OracleDbType.Int32);
                            orderIdParam.Direction = ParameterDirection.Output;
                            orderCmd.Parameters.Add(orderIdParam);

                            orderCmd.ExecuteNonQuery();
                            newOrderId = Convert.ToInt32(orderIdParam.Value.ToString());
                        }

                        // 2. 循环处理购物车项
                        foreach (var item in cartItems)
                        {
                            // 插入详情表
                            string detailsSql = "INSERT INTO Contains (order_id, drink_id, quantity) VALUES (:order_id, :drink_id, :quantity)";
                            using (OracleCommand detailsCmd = new OracleCommand(detailsSql, conn))
                            {
                                detailsCmd.Transaction = transaction;
                                detailsCmd.BindByName = true;
                                detailsCmd.Parameters.Add("order_id", OracleDbType.Int32).Value = newOrderId;
                                detailsCmd.Parameters.Add("drink_id", OracleDbType.Int32).Value = item.DrinkId;
                                detailsCmd.Parameters.Add("quantity", OracleDbType.Int32).Value = item.Quantity;
                                detailsCmd.ExecuteNonQuery();
                            }

                            // 扣减库存
                            string stockSql = "UPDATE Drinks SET stock = stock - :qty WHERE drink_id = :id AND stock >= :qty";
                            using (OracleCommand stockCmd = new OracleCommand(stockSql, conn))
                            {
                                stockCmd.Transaction = transaction;
                                stockCmd.BindByName = true;
                                stockCmd.Parameters.Add("qty", OracleDbType.Int32).Value = item.Quantity;
                                stockCmd.Parameters.Add("id", OracleDbType.Int32).Value = item.DrinkId;

                                if (stockCmd.ExecuteNonQuery() == 0)
                                    throw new Exception($"饮品 ID {item.DrinkId} 库存不足！");
                            }
                        }

                        transaction.Commit();
                        return (true, $"下单成功！");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return (false, $"交易失败: {ex.Message}");
                    }
                }
            }
        }

        // 获取历史订单（包含饮品信息）
        public DataTable GetOrderHistory(string phone)
        {
            DataTable dt = new DataTable();
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // 使用XMLAGG来拼接订单详情，避免字符串长度限制
                    string sql = @"
                SELECT 
                    TO_CHAR(o.order_time, 'YYYY-MM-DD HH24:MI:SS') AS OrderTime,
                    o.total_amount AS TotalAmount,
                    RTRIM(XMLAGG(XMLELEMENT(e, d.name || '×' || c.quantity, ', ') 
                          ORDER BY d.name).EXTRACT('//text()').GetClobVal(), ', ') AS Items
                FROM Orders o
                JOIN Contains c ON o.order_id = c.order_id
                JOIN Drinks d ON c.drink_id = d.drink_id
                WHERE o.phone = :phone
                GROUP BY o.order_id, o.order_time, o.total_amount
                ORDER BY o.order_time DESC";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 如果XMLAGG失败，尝试使用LISTAGG（Oracle 11g R2+）
                    try
                    {
                        dt = new DataTable(); // 重新初始化
                        string sql2 = @"
                    SELECT 
                        TO_CHAR(o.order_time, 'YYYY-MM-DD HH24:MI:SS') AS OrderTime,
                        o.total_amount AS TotalAmount,
                        LISTAGG(d.name || '×' || c.quantity, ', ') WITHIN GROUP (ORDER BY d.name) AS Items
                    FROM Orders o
                    JOIN Contains c ON o.order_id = c.order_id
                    JOIN Drinks d ON c.drink_id = d.drink_id
                    WHERE o.phone = :phone
                    GROUP BY o.order_id, o.order_time, o.total_amount
                    ORDER BY o.order_time DESC";

                        using (OracleCommand cmd = new OracleCommand(sql2, conn))
                        {
                            cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        // 如果都失败，使用简单的分组查询
                        dt = new DataTable();
                        string sql3 = @"
                    SELECT 
                        TO_CHAR(o.order_time, 'YYYY-MM-DD HH24:MI:SS') AS OrderTime,
                        o.total_amount AS TotalAmount,
                        (SELECT COUNT(*) FROM Contains c2 WHERE c2.order_id = o.order_id) AS ItemCount
                    FROM Orders o
                    WHERE o.phone = :phone
                    ORDER BY o.order_time DESC";

                        using (OracleCommand cmd = new OracleCommand(sql3, conn))
                        {
                            cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            return dt;
        }

        // 根据手机号获取用户姓名
        public string GetName(string phone)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT name FROM Users WHERE phone = :phone";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return "用户不存在";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 可以选择记录日志
                return $"获取姓名失败: {ex.Message}";
            }
        }

        // 获取用户详细信息
        public UserInfo GetUserDetail(string phone)
        {
            var userInfo = new UserInfo { Phone = phone };

            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();

                    // 1. 获取用户基本信息
                    string userSql = @"
                SELECT name, address 
                FROM Users 
                WHERE phone = :phone";

                    using (OracleCommand cmd = new OracleCommand(userSql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userInfo.Name = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                userInfo.Address = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            }
                        }
                    }

                    // 2. 获取用户订单统计
                    string statsSql = @"
                SELECT 
                    COUNT(*) as order_count,
                    COALESCE(SUM(total_amount), 0) as total_amount
                FROM Orders 
                WHERE phone = :phone";

                    using (OracleCommand cmd = new OracleCommand(statsSql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userInfo.OrderCount = reader.GetInt32(0);
                                userInfo.TotalAmount = reader.GetDecimal(1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取用户信息失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return userInfo;
        }

        // 修改用户信息（姓名和地址）
        public (bool Success, string Message) UpdateUserInfo(string phone, string name, string address)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = @"
                UPDATE Users 
                SET name = :name, 
                    address = :address
                WHERE phone = :phone";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("name", OracleDbType.Varchar2, 30).Value = name;
                        cmd.Parameters.Add("address", OracleDbType.Varchar2, 50).Value =
                            string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address;
                        cmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;

                        int rows = cmd.ExecuteNonQuery();
                        return (rows > 0, rows > 0 ? "个人信息修改成功" : "修改失败，用户不存在");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, $"修改失败: {ex.Message}");
            }
        }

        // 修改密码
        public (bool Success, string Message) ChangePassword(string phone, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    return (false, "新密码不能为空");
                }

                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();

                    // 1. 验证旧密码
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE phone = :phone AND password = :oldPassword";
                    using (OracleCommand checkCmd = new OracleCommand(checkSql, conn))
                    {
                        checkCmd.BindByName = true;
                        checkCmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                        checkCmd.Parameters.Add("oldPassword", OracleDbType.Varchar2, 50).Value = oldPassword;

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count == 0)
                        {
                            return (false, "旧密码错误");
                        }
                    }

                    // 2. 更新密码
                    string updateSql = "UPDATE Users SET password = :newPassword WHERE phone = :phone";
                    using (OracleCommand updateCmd = new OracleCommand(updateSql, conn))
                    {
                        updateCmd.BindByName = true;
                        updateCmd.Parameters.Add("newPassword", OracleDbType.Varchar2, 50).Value = newPassword;
                        updateCmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;

                        int rows = updateCmd.ExecuteNonQuery();
                        return (rows > 0, rows > 0 ? "密码修改成功" : "密码修改失败");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, $"修改密码失败: {ex.Message}");
            }
        }

        // 注销用户（删除账号）
        public (bool Success, string Message) DeleteUser(string phone, string password)
        {
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                using (OracleTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. 验证密码
                        string checkSql = "SELECT COUNT(*) FROM Users WHERE phone = :phone AND password = :password";
                        using (OracleCommand checkCmd = new OracleCommand(checkSql, conn))
                        {
                            checkCmd.Transaction = transaction;
                            checkCmd.BindByName = true;
                            checkCmd.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            checkCmd.Parameters.Add("password", OracleDbType.Varchar2, 50).Value = password;

                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (count == 0)
                            {
                                transaction.Rollback();
                                return (false, "密码错误，无法注销");
                            }
                        }

                        // 2. 先删除订单详情（由于外键约束）
                        string deleteContainsSql = @"
                    DELETE FROM Contains 
                    WHERE order_id IN (SELECT order_id FROM Orders WHERE phone = :phone)";
                        using (OracleCommand cmd1 = new OracleCommand(deleteContainsSql, conn))
                        {
                            cmd1.Transaction = transaction;
                            cmd1.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            cmd1.ExecuteNonQuery();
                        }

                        // 3. 删除订单
                        string deleteOrdersSql = "DELETE FROM Orders WHERE phone = :phone";
                        using (OracleCommand cmd2 = new OracleCommand(deleteOrdersSql, conn))
                        {
                            cmd2.Transaction = transaction;
                            cmd2.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            cmd2.ExecuteNonQuery();
                        }

                        // 4. 最后删除用户
                        string deleteUserSql = "DELETE FROM Users WHERE phone = :phone";
                        using (OracleCommand cmd3 = new OracleCommand(deleteUserSql, conn))
                        {
                            cmd3.Transaction = transaction;
                            cmd3.Parameters.Add("phone", OracleDbType.Varchar2, 11).Value = phone;
                            int rows = cmd3.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                transaction.Commit();
                                return (true, "账号注销成功");
                            }
                            else
                            {
                                transaction.Rollback();
                                return (false, "注销失败");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return (false, $"注销失败: {ex.Message}");
                    }
                }
            }
        }
    }
}