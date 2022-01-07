SELECT 
	p.Id, p.Name, p.Description, p.Price, 
	sc.Name as SubCategory, 
	c.Name as Category 
FROM Products p 
JOIN SubCategories sc ON sc.Id = p.SubCategoryId 
JOIN Categories c ON c.Id = sc.CategoryId 