-- =============================================
-- Author:		Pimentel, Daniel
-- Create date: 12/17/2019
-- Description:	The ninth part of question 10
-- =============================================
CREATE PROCEDURE dbo.Question10Part9
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET QUOTED_IDENTIFIER ON;

    BEGIN TRY
        SELECT P.Category,
               COUNT(S.SaleID) AS NumberOfSales
        FROM dbo.Products AS P
            INNER JOIN dbo.Sales AS S
                ON P.ProductID = S.ProductID
        WHERE S.SalePrice - P.RecommendedPrice >= 10
        GROUP BY P.Category;
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