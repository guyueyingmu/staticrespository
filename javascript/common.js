(function(window){
	var document   = window.document
	, _hd    = window.hd={
		
	};		
})(window);


/* ȥ����β�ո� */
function trim(str){
	 str.replace(/^\s+|\s+$/g, "")   
}

/* ͨ��Ԫ��id����Ԫ�� */
function $(id){
		return document.getElementById(id);
}

/* ��source�зǿ�������дĬ�϶����е����� */
function extend (destination, source) {     
	var o = {};       
	for (var property in source) {
		if (source[property] || source[property] == 0)
		o[property] = source[property];   
	}
	return o;   
}

/* �ַ����ַ����� */
function getStrActualLen(sChars){
	sChars = $.trim(sChars);
	var len = 0;
	for(i=0;i<sChars.length;i++){
		iCode = sChars.charCodeAt(i);
		if((iCode>=0 && iCode<=255)||(iCode>=0xff61 && iCode<=0xff9f)){
			len += 1;
		}else{
			len += 2;
		}
	}
	return len;
}


