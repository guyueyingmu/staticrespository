
//sql2005  row_number ��ҳ����
select * from (select row_number() over(order by id desc) as rownum, * from testtable) a where rownum between 11 and 20 --������

//not top��ҳ���� ������ǰ����ҳ��
select top 10 * from testtable where id not in (select top 10 id from testtable order by id desc ) order by id desc 

//ȡtop��¼���С�ļ�¼����Ȼ����ȡid��С����top��¼
select top 10 * from testtable where id < (select min(id) from (select top 10 id from testtable order by id desc) a) order by id desc 


�ܽ᣺��2,3�������ƣ�
1. sqlserver 2005  row_number() over ��ҳ
2. ����top�б�
3. ȡtop�б�߽�idֵ���бȽ�


