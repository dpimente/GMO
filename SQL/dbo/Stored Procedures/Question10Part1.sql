-- =============================================
-- Author:		Pimentel, Daniel
-- Create date: 12/17/2019
-- Description:	The first part of question 10
-- =============================================
CREATE PROCEDURE Question10Part1
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
               P.ProductName,
               S.SalePrice
        FROM dbo.Sales AS S
            INNER JOIN dbo.Customers AS C
                ON S.CustomerID = C.CustomerID
            INNER JOIN dbo.Products AS P
                ON S.ProductID = P.ProductID
        WHERE MONTH(S.SaleDate) = 10
              AND YEAR(S.SaleDate) = 2005;
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