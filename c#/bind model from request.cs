/// <summary>
/// ��request�л�ȡֵ�Զ��󶨵�����
/// </summary>
/// <returns></returns>
Product BuildProdctFromRequest()
{
	string[] keyAry = Request.Form.AllKeys;

	Product p = new Product();
	foreach (string key in keyAry)
	{
		//��ȡָ���ֶ�
		FieldInfo fi  = p.GetType().GetField(key);
		if (fi != null)
		{
			if (string.IsNullOrEmpty(Request.Form[key]) == false)
			{
				//�ֶ�����
				Type t = fi.FieldType;

				//�����ֶ�ֵ�� �Զ�ת������
				fi.SetValue(p, Convert.ChangeType(Request.Form[key], t));
			}
		}
	}
	return p;
}