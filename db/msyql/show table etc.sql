
--show index and engine ������������Ϣ
	show create table product;

--show size infomation ��Ĵ�С��Ϣ
	show table status like 'product'\G

--clues of inefficiencies ��Ч��ѯ����
	EXPLAIN SELECT * from product limit 1;

-- չʾmysql������Ϣ
SHOW VARIABLES LIKE '%buffer%';