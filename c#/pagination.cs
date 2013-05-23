private void getPageHtml(int pageIndex, int recordcount)
{
	//����һҳ
	if (recordcount <= PageSize)
		return;

	if (pageIndex == 0)
		pageIndex = 1;
	string _url = HttpContext.Current.Request.Url.PathAndQuery.ToString();
	string _regular = "page=[0-9]";
	Regex reg = new Regex(_regular);
	if (reg.IsMatch(_url))
	{
		_url = Regex.Replace(_url, _regular, "", RegexOptions.IgnoreCase);
	}//if
	if (_url.IndexOf("?") <= 0)
		_url += "?page=";
	else
		_url += "&page=";
	_url = _url.Replace("&&", "&");

	int pagecount = (int)Math.Ceiling(recordcount / PageSize * 1.0);//��ҳ��
	int start = 1, end = 10;
	bool isendpagenum = false;
	if (pageIndex > 5)
	{
		if (pageIndex + 5 < pagecount)
		{
			end = pageIndex + 5;
			start = pageIndex - 4;
		}
		else
		{
			end = pagecount;
			start = pagecount - 9;
			isendpagenum = true;
		}
	}
	StringBuilder sb = new StringBuilder();

	//�����ҳ��
	if (pageIndex > 5)
		sb.AppendLine("<a href='" + _url + "1' >��ҳ</a>");

	for (int i = start; i < end + 1; i++)
	{
		if (i == pageIndex)
		{
			sb.AppendLine("<span style='margin-right:5px;font-weight:Bold;color:red;'>" + pageIndex + "</span>");
			continue;
		}
		sb.AppendLine("<a href='" + _url + i.ToString() + "' >"+i.ToString()+"</a>");
	}

	if (!isendpagenum)
		sb.AppendLine("<a href='" + _url + pagecount.ToString() + "' >ĩҳ</a>");

	sb.AppendLine("<a href='" + _url + (pageIndex + 1).ToString() + "'>��һҳ</a>");
	sb.AppendLine("ת��<input type='text' value='" + pageIndex.ToString() + "' name='PagerInput' id='PagerInput' style='width:30px;' />ҳ<input type='Button' name='AspNetPager1' id='AspNetPager1_btn' value='Go' onclick=\"javascript:jumpto(document.getElementById('PagerInput').value);\" />");
	this.htmlpage.InnerHtml = sb.ToString();
}
