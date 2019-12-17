-- =============================================
-- Author:		Pimentel, Daniel
-- Create date: 12/17/2019
-- Description:	The seventh part of question 10
-- =============================================
CREATE PROCEDURE dbo.Question10Part7
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET QUOTED_IDENTIFIER ON;

    BEGIN TRY
        SELECT C.FirstName,
               C.LastName,
               P.Category,
               AVG(S.SalePrice) AS AverageSalesPriceForCategoryPurchasePerCustomer
        FROM dbo.Customers AS C
            INNER JOIN dbo.Sales AS S
                ON S.CustomerID = C.CustomerID
            INNER JOIN dbo.Products AS P
                ON S.ProductID = P.ProductID
        GROUP BY C.CustomerID,
                 C.FirstName,
                 C.LastName,
                 S.ProductID,
                 P.Category
        HAVING COUNT(S.SaleId) >= 2
        ORDER BY C.CustomerID;

    -- Not sure what to output exactly from the question. So Here's just the customer, product and Ave sales price 

    --Select c.CustomerID, s.ProductID, AVG(S.SalePrice)
    --from dbo.Customers as C
    --	inner join dbo.Sales as S on S.CustomerID = C.CustomerID
    --Group By C.CustomerID, ProductID
    --Having COUNT(S.SaleId) >= 2
    --order by C.CustomerID
    END TRY
    BEGIN CATCH
        DECLARE @ErrorNumber INT = ERROR_NUMBER();
        DECLARE @ErrorLine INT = ERROR_LINE();
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;