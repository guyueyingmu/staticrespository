

/*
ԭ��
ҳ��С�ڵ���5ʱ���������⴦��
����5֮�󣬵�ǰҳ��ǰ��ȡ4ҳ������ȡ5ҳ
*/

function pagination(pageIndex, pageSize, totalRecord){
	var pageCount = Math.ceil(totalRecord / pageSize); //������ҳ
	var start,end,isendpagenum = false;
	if(pageIndex>5){
		if(pageIndex+5<pageCount){
			end = pageIndex + 5;
			start = pageIndex - 4;
		}
		else{
			end = pageCount;
			start = pageCount - 9;
			isendpagenum=true;
		}
	}
	//�����ҳ��
	if(pageIndex>5)
		document.write(1+"....<br/>");
	for (var i=start; i<end+1; i++)
	{

		if(i==pageIndex){
			document.write('<span style="color:red;">'+i+'</span><br/>');
			continue;
		}
		document.write(i+"<br/>");
	}
	if(!isendpagenum)
		document.write(pageCount+"....<br/>");
}

pagination(95, 10, 999);