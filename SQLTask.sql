SELECT Products.Name, Categories.Name 
FROM Products
LEFT JOIN Pairs
ON Products.Id = Pairs.ProductId
LEFT JOIN Categories
ON Pairs.CategoryId = Categories.Id