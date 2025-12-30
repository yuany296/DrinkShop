-- 清屏命令
clear screen
-- 删除序列（如果存在）
drop sequence seq_drink_id;
drop sequence seq_order_id;
-- 由于完整性约束，删除表的顺序很重要
drop table Contains;
drop table Orders;
drop table Drinks;
drop table Users;

create table Users(
    phone varchar2(11) not null,
    name varchar2(30) not null,
    address varchar2(50),
    password varchar2(50) not null,
    constraint pk_user primary key(phone),
    constraint chk_phone_length check(length(phone)=11 and regexp_like(phone, '^[0-9]+$'))
);
    
create table Drinks(
    drink_id number not null,
    name varchar2(30) not null,
    type varchar2(10) not null,
    price number(10,2) not null,
    stock number not null,
    constraint pk_drink primary key(drink_id),
    constraint chk_price check(price>0),
    constraint chk_stock check(stock>=0)
);
    
create table Orders(
    order_id number not null,
    phone varchar2(11) not null,
    order_time timestamp default current_timestamp not null,
    total_amount number(10,2) not null,
    constraint pk_order primary key(order_id),
    constraint fk_order_user foreign key(phone) references Users(phone),
    constraint chk_total_amount check(total_amount>=0)
);
    
create table Contains(
    order_id number not null,
    drink_id number not null,
    quantity number not null,
    constraint pk_contains primary key(order_id,drink_id),
    constraint fk_contains_order foreign key(order_id) references Orders(order_id) on delete cascade,
    constraint fk_contains_drink foreign key(drink_id) references Drinks(drink_id),
    constraint chk_quantity check(quantity>0)
);
    
-- 创建序列
create sequence seq_drink_id 
    start with 1 
    increment by 1 
    nocache nocycle;

create sequence seq_order_id 
    start with 1 
    increment by 1 
    nocache nocycle;

--插入饮料
-- 奶茶类
insert into Drinks values(seq_drink_id.nextval, '珍珠奶茶', '奶茶', 10.00, 35);
insert into Drinks values(seq_drink_id.nextval, '焦糖布丁奶茶', '奶茶', 11.00, 30);
insert into Drinks values(seq_drink_id.nextval, '芋泥芋圆奶茶', '奶茶', 14.00, 25);
insert into Drinks values(seq_drink_id.nextval, '布丁西米露', '奶茶', 10.00, 40);

-- 咖啡类
insert into Drinks values(seq_drink_id.nextval, '美式咖啡', '咖啡', 15.00, 30);
insert into Drinks values(seq_drink_id.nextval, '香草拿铁', '咖啡', 18.00, 35);
insert into Drinks values(seq_drink_id.nextval, '卡布奇诺', '咖啡', 20.00, 30);

-- 果茶类
insert into Drinks values(seq_drink_id.nextval, '蜂蜜柠檬茶', '果茶', 12.00, 45);
insert into Drinks values(seq_drink_id.nextval, '满杯百香果', '果茶', 16.00, 35);
insert into Drinks values(seq_drink_id.nextval, '霸气葡萄', '果茶', 18.00, 30);
insert into Drinks values(seq_drink_id.nextval, '杨枝甘露', '果茶', 16.00, 30);
insert into Drinks values(seq_drink_id.nextval, '多肉青提', '果茶', 15.00, 2);

-- 奶盖茶类 
insert into Drinks values(seq_drink_id.nextval, '芝士奶盖四季春', '奶盖茶', 18.00, 30);
insert into Drinks values(seq_drink_id.nextval, '海盐奶盖乌龙', '奶盖茶', 20.00, 30);


commit;

