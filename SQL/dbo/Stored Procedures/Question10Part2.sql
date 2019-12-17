-- =============================================
-- Author:		Pimentel, Daniel
-- Create date: 12/17/2019
-- Description:	The second part of question 10
-- =============================================
CREATE PROCEDURE dbo.Question10Part2
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET QUOTED_IDENTIFIER ON;

    BEGIN TRY
        SELECT CustomerID,
               FirstName,
               LastName
        FROM dbo.Customers
        WHERE CustomerID NOT IN
              (
                  SELECT CustomerID FROM dbo.Sales
              );
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