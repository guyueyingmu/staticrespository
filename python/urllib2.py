
### ��װһ������Handlerʾ��
proxy = urllib2.ProxyHandler({'http': ip_port})
opener = urllib2.build_opener(proxy) #������handler���뵽��ʽhandler�б� ����һ��OpenerDirector
urllib2.install_opener(opener)	#��ָ��opener��OpenerDirector���������� ȫ�ֵ�
try:
	r=urllib2.urlopen(self.proxy_test_url, timeout=5)
	if r:
		http_ip_port = 'http://' + ip_port
		self.proxies.append(http_ip_port)
		if f:
			f.write(http_ip_port + '\r\n')
		print ip_port + ' is ok!'
except Exception as inst:
	print inst


### ��װһ����cookie���ܵ�����
import urllib, urllib2, cookielib

cookie = cookielib.CookieJar()
opener = urllib2.build_opener(urllib2.HTTPCookieProcessor(cookie))

### post ���ҽ���cookie
response=opener.open(login_url, urllib.urlencode(login_params))


### request �������ͷ
request=urllib2.Request(addtopicurl)
request.add_header("User-Agent","Mozilla/5.0 (Windows NT 6.1) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.57 Safari/536.11")
request.add_header("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3")
request.add_header("Origin", "http://www.douban.com")
request.add_header("Referer", "http://www.douban.com/group/python/new_topic")


### ���cookie
for c in cookie:
    print c