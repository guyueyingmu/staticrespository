# -- coding:gbk --
import sys, time, os, re
import urllib, urllib2, cookielib

def get_str_from_text(re_str, text):
	a = re.search(re_str, text)
	if a:
		return a.group(1)
	return ""


loginurl = 'https://www.douban.com/accounts/login'
cookie = cookielib.CookieJar()
opener = urllib2.build_opener(urllib2.HTTPCookieProcessor(cookie))

params = {
"form_email":"terrygon@163.com",
"form_password":"123456test",
"source":"index_nav" #û�еĻ���¼���ɹ�
}

#����ҳ�ύ��¼
response=opener.open(loginurl, urllib.urlencode(params))

#��֤�ɹ���ת����¼ҳ
if response.geturl() == "https://www.douban.com/accounts/login":
	html=response.read()

	#��֤��ͼƬ��ַ
	imgurl=re.search('<img id="captcha_image" src="(.+?)" alt="captcha" class="captcha_image"/>', html)
	if imgurl:
		url=imgurl.group(1)
		#��ͼƬ������ͬĿ¼��
		res=urllib.urlretrieve(url, 'v.jpg')
		#��ȡcaptcha-id����
		captcha=re.search('<input type="hidden" name="captcha-id" value="(.+?)"/>' ,html)
		if captcha:
			vcode=raw_input('������ͼƬ�ϵ���֤�룺')
			params["captcha-solution"] = vcode
			params["captcha-id"] = captcha.group(1)
			params["user_login"] = "��¼"
			#�ύ��֤����֤
			response=opener.open(loginurl, urllib.urlencode(params))
			''' ��¼�ɹ���ת����ҳ '''
			if response.geturl() == "http://www.douban.com/":
				print 'login success ! (have validate image)'
else:
	print 'login success ! (have no validate image)'


#������
doumail_url = "http://www.douban.com/doumail/49589762/"
doumail_url1 = "http://www.douban.com/doumail/write?to=49589762"


for i in range(10):

	try:
		response=opener.open(doumail_url)
	except:
		response=opener.open(doumail_url1)
		doumail_url = doumail_url1

	html=response.read()	
	ck_val = get_str_from_text('<input type="hidden" name="ck" value="(.+?)"/>', html)
	captcha_id_val = get_str_from_text('<input type="hidden" name="captcha-id" value="(.+?)"/>', html)
	captcha_img_val = get_str_from_text('<img src="(.+?)" alt="captcha"/>', html)

	vcode=''
	if captcha_id_val:
		#��ͼƬ������ͬĿ¼��
		res=urllib.urlretrieve(captcha_img_val, 'v.jpg')
		vcode=raw_input('������ͼƬ�ϵ���֤�룺')

	content = u"��ã�������"

	params = {
	"to":"49589762",
	"action":"m_reply",
	"m_text":content.encode('utf-8'),
	"captcha-id":captcha_id_val, 
	"captcha-solution":vcode,
	"ck":ck_val
	}

	request=urllib2.Request(doumail_url)
	request.add_header("User-Agent","Mozilla/5.0 (Windows NT 6.1) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.57 Safari/536.11")
	request.add_header("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3")
	request.add_header("Origin", "http://www.douban.com")
	request.add_header("Referer", "http://www.douban.com/")
	opener.open(request, urllib.urlencode(params))

	print '���ͳɹ�'
	time.sleep(30)