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