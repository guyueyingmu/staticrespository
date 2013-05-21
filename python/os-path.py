# -- coding:utf-8 --
# python·�����ú��� os.path #

import os

#����Ŀ¼�����ļ��� = os.path.split(path)[1]
os.path.basename(path)

#�����ļ�Ŀ¼����·���ĸ�Ŀ¼ = os.path.split(path)[0]
os.path.dirname(path)

#�ж��ļ���Ŀ¼�Ƿ����
os.path.exists(path)

#ƴ��·���� ��ϵͳ�ָ��� (os.sep)
os.path.join(path1,path2)

#�淶��·��������б��תΪб�ܣ���ĸתΪСд
os.path.normcase('c:\Test') #'c:/test' 

#��·����Ϊһ��Ԫ�飬�����һ��б��Ϊ�ֽ��ߣ�������һ���ַ�Ϊб�ܣ���ô���صĵ�2��Ԫ��Ϊ��
os.path.split('c:/1/')  #('c:/1', '')
os.path.split('c:/1')  #('c:/', '1')
os.path.split('c:/1/1.txt') #('c:/1', '1.txt')

#��·��ת��Ϊһ��Ԫ�棬���ΪĿ¼��ڶ���Ԫ��Ϊ�գ�����ļ���ڶ���Ԫ��Ϊ�ļ���չ��
os.path.splitext('c:/1') #('c:/1, '')
os.path.splitext('c:/1/1.txt') #('c:/1', '.txt')

#os.path.walk(path, visit, arg) 
#����Ŀ¼����Ŀ¼
#path:��������Ŀ¼ visit(arg, dirname, names) ����Ŀ¼�ĺ��� dirnameĿ¼����namesĿ¼���ļ���(Ҳ����Ŀ¼)���б�
def showfiles(arg, dirname, names):
 print "Ŀ¼��%s" % dirname
 #os.path.joinƴ��·��
 #os.path.isfile�ж��Ƿ�Ϊ�ļ� os.path.isdir�ж��Ƿ�ΪĿ¼
 names=[n for n in names if os.path.isfile(os.path.join(dirname,n))]
 print "Ŀ¼���ļ���%s" % ','.join(names)
os.path.walk('E:/python/walk', showfiles, '')