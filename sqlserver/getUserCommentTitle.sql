
create  FUNCTION [dbo].[getUserCommentTitle] 
(	
	@Source INT,
	@CmtTitle VARCHAR(255),
	@CmtContent TEXT,
	@MainTitle VARCHAR(255),
	@CommentImages varchar(255),
	@CommentVideo varchar(512)
)
RETURNS varchar(255)
AS
BEGIN
	DECLARE @title VARCHAR(255)
	SET @title = @CmtTitle 
	IF (@Source >= 1 AND @source <=7)
	begin
		IF @Source = 1 
	   	SET @title = '�����ʻ���'
		IF @Source = 2 
	   	SET @title = '�Ӹ�������'
	   	IF @Source = 3 
	   	SET @title = '��ö��ʯ��'
	   	IF @Source = 4 
	   	SET @title = '��Ϊ��ʣ�'
	   	IF @Source = 5 
	   	SET @title = '�����ٶȣ�'
	   	IF @Source = 6
	   	SET @title = '�屭���ȣ�'
	   	IF @Source = 7 
	   	SET @title = '�ͺɰ�����'	   	
	   	SET @title = 'Ϊ' + @MainTitle + @title
	   	RETURN @title
   	END 
   	
   	IF @CommentImages IS NOT NULL OR @CommentImages <> ''
   	BEGIN
   		IF @CmtTitle IS NULL OR @CmtTitle = ''
   		BEGIN
   			SET @title = ltrim(rtrim(substring(@CmtContent, 1, 46)))  + '(ͼƬ)'
   		END 
   		ELSE
   		BEGIN
   			SET @title = @CmtTitle + '(ͼƬ)'
   		END
   	END 
   	
   	
   	IF @CommentVideo IS NOT NULL OR @CommentVideo <> ''
   	BEGIN
   		IF @CmtTitle IS NULL OR @CmtTitle = ''
   		BEGIN
   			SET @title = ltrim(rtrim(substring(@CmtContent, 1, 46)))  + '(��Ƶ)'
   		END 
   		ELSE
   		BEGIN
   			SET @title = @CmtTitle + '(��Ƶ)'
   		END
   	END 
   	
   	IF @title IS NULL OR @title = ''
   		SET @title = ltrim(rtrim(substring(@CmtContent, 1, 50)))
   	
   	RETURN @title
END

