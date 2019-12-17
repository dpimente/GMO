-- =============================================
-- Author:		Pimentel, Daniel
-- Create date: 12/17/2019
-- Description:	The third part of question 10
-- =============================================
CREATE PROCEDURE dbo.Question10part3
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
               S.SalePrice,
               P.RecommendedPrice,
               ABS(S.SalePrice - P.RecommendedPrice) AS DifferenceInPricing
        FROM dbo.Sales AS S
            INNER JOIN dbo.Customers AS C
                ON S.CustomerID = C.CustomerID
            INNER JOIN dbo.Products AS P
                ON S.ProductID = P.ProductID;
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