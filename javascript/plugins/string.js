
/* ȥ����β�ո� */
function trim(str){
	return str.replace(/^\s+|\s+$/g, "");
}

/* ��ȡ�ַ����ַ����� �����ֽ��㣩 */
function str_len(str){
	str = trim(str);
	var len = 0;
	for(var i=0;i<str.length;i++){
		code = str.charCodeAt(i);
		if((code>=0 && code<=255)||(code>=0xff61 && code<=0xff9f)){
			len += 1;
		}else{
			len += 2;
		}
	}
	return len;
}