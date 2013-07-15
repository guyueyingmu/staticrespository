/* ����͸����style */
function SetOpacity(ev, v){
	ev.filters ? ev.style.filter = 'alpha(opacity=' + v + ')' : ev.style.opacity = v / 100;
}
	
var defaultoptions = {"speed":20, "opacity":100, "callback":null}        

//����Ч��(�����뵽ָ��͸����)
function fadeIn(elem, options){	    
	options = extend(defaultoptions, options);
	speed = options.speed || 20;
	opacity = options.opacity || 100;
	//��ʾԪ��,����Ԫ��ֵΪ0͸����(���ɼ�)
	elem.style.display = 'block';
	//��ʼ��͸���ȱ仯ֵΪ0
	var val = 0;
	//ѭ����͸��ֵ��5����,������Ч��
	(function(){
		SetOpacity(elem, val);
		val += 5;
		if (val <= opacity) {
			setTimeout(arguments.callee, speed)
		}else{
			if (options.callback)
				options.callback();
		}
	})();	
}

//����Ч��(��������ָ��͸����)
function fadeOut(elem, options){
	options = extend(defaultoptions, options);	    
	speed = options.speed || 20;
	opacity = options.opacity || 0;
	//��ʼ��͸���ȱ仯ֵΪ0
	var val = 100;
	//ѭ����͸��ֵ��5�ݼ�,������Ч��
	(function(){
		SetOpacity(elem, val);
		val -= 5;
		if (val >= opacity) {
			setTimeout(arguments.callee, speed);
		}else if (val < 0) {
			//Ԫ��͸����Ϊ0������Ԫ��
			elem.style.display = 'none';	                
			if (options.callback)
				options.callback();	            
		}
	})();
}
