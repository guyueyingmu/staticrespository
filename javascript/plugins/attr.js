/* ����Ԫ������ֵ */
function set_attr(obj, name, value){
	obj.setAttribute(name, value);
}

/*  ��ȡԪ������ֵ */
function get_attr(obj, name){
	return obj.getAttribute(name);
}

/* �Ƴ�Ԫ������ */
function rem_attr(obj, name){
	obj.removeAttribute(name);
}

/* ����Ԫ����ʽ */
function set_class(obj, value){
	set_attr(obj, "class", value);
	set_attr(obj, "className", value);
}

/* �Ƴ�Ԫ����ʽ */
function rem_class(obj){
	remove_attr(obj, "class");
	remove_attr(obj, "className");
}