/// <summary>
/// ��DataReader�󶨵���������
/// </summary>
/// <param name="reader"></param>
/// <returns></returns>
private Product BuildProductByDataReader(SqlDataReader reader)
{
	Product p = new Product();
	while (reader.Read())
	{
		int fieldCount = reader.FieldCount;
		for (int i = 0; i < fieldCount; i++)
		{
			//����
			string fieldName = reader.GetName(i);
			//�ֶζ���
			FieldInfo fi = p.GetType().GetField(fieldName);

			if (fi == null)
				continue;

			//�ֶ�����
			Type fieldType = fi.FieldType;
			//��ֵ
			if (fi != null)
				fi.SetValue(p, Convert.ChangeType(reader[i], fieldType));
		}
	}
	return p;
}