(function(window){
	var document   = window.document
	, _hd    = window.hd={
		
	};		
})(window);


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

/* �Ƿ�δ���� */
function is_undefined(obj){
	return typeof(obj) == "undefined";
}

/* �ж��Ƿ�Ϊ�գ� ����Ϊ0��ʾ�� */
function is_empty(obj){
	return is_undefined(obj) || obj.length == 0;
}

/* �����ղؼ� */
function bookmarkit()
{
   if (document.all)
   {
      try
          {window.external.addFavorite('http://mall.hongxiu.com/','��ױ-���������̳�');}
      catch (e)
          {alert("�����������֧�ִ˹��ܡ������԰� Ctrl+D ��һ�¡�");}
   }
   else if (window.sidebar)
      {
	try
          {window.sidebar.addPanel('��ױ-���������̳�', 'http://mall.hongxiu.com/',  "");}
      catch (e)
          {alert("�����������֧�ִ˹��ܡ������԰� Ctrl+D ��һ�¡�");}
       }
    else
      {alert("�����������֧�ִ˹��ܡ������԰� Ctrl+D ��һ�¡�");}
}