mysqldump -u�û��� -p���� ���ݿ��� ���� --where="ɸѡ����" > �����ļ�·��

0.�������ݿ� ����ṹ�����ݶ�������
mysqldump -uroot -pabc freeb2b > fb.bak		��

1.�����ṹ����������
mysqldump -d ���ݿ��� -uroot -p > xxx.sql	��

2.�������ݲ������ṹ
mysqldump -t ���ݿ��� -uroot -p > xxx.sql

3.�����ض���Ľṹ --table ��������ָ�������
mysqldump -uroot -pabc -B freeb2b --table company product > fb		��

����ĳ�����е�һЩ����
mysqldump -uroot -pabc freeb2b product --where="id=1" > 1.sql		��


***************************************mysqldump֧������ѡ�**************************
--add-drop-table   
��ÿ��create���֮ǰ����һ��drop table��   

--allow-keywords   
�������ǹؼ��ʵ������֡����ɱ���ǰ׺��ÿ������������   

-c, --complete-insert   
ʹ��������insert���(��������)��   


***************************************�������ݣ�**************************
mysql ���ݿ��� < �ļ���