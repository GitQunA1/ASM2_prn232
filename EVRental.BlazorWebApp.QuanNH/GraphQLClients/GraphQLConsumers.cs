using EVRental.BlazorWebApp.QuanNH.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Transport;
using GraphQLRequest = GraphQL.GraphQLRequest;

namespace EVRental.BlazorWebApp.QuanNH.GraphQLClients
{
    public class GraphQLConsumers
    {
        private readonly IGraphQLClient _graphQLClient;

        public GraphQLConsumers(IGraphQLClient graphQLClient)
        {
            _graphQLClient = graphQLClient;
        }

        public async Task<List<CheckOutQuanNh>> GetCheckOutQuanNhs()
        {
            try
            {
                var query = @"query CheckOutQuanNhs {
                            checkOutQuanNhs {
                                checkOutQuanNhid
                                checkOutTime
                                returnDate
                                extraCost
                                totalCost
                                lateFee
                                isPaid
                                isDamageReported
                                notes
                                customerFeedback
                                paymentMethod
                                staffSignature
                                customerSignature
                                returnConditionId
                                returnCondition {
                                    returnConditionId
                                    name
                                    severityLevel
                                    repairCost
                                }
                            }
                        }";

                var response = await _graphQLClient.SendQueryAsync<CheckOutQuanNhsGraphQLResponse>(query);
                var result = response?.Data?.checkOutQuanNhs?.ToList();

                return result ?? new List<CheckOutQuanNh>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GraphQL Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateCheckOutQuanNh(CheckOutQuanNh entity)
        {
            try
            {
                var input = new
                {
                    checkOutQuanNhid = 0,
                    checkOutTime = entity.CheckOutTime?.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    returnDate = entity.ReturnDate?.ToString("yyyy-MM-dd"),
                    extraCost = entity.ExtraCost,
                    totalCost = entity.TotalCost,
                    lateFee = entity.LateFee,
                    isPaid = entity.IsPaid,
                    isDamageReported = entity.IsDamageReported,
                    notes = entity.Notes,
                    customerFeedback = entity.CustomerFeedback,
                    paymentMethod = entity.PaymentMethod,
                    staffSignature = entity.StaffSignature,
                    customerSignature = entity.CustomerSignature,
                    returnConditionId = entity.ReturnConditionId
                };

                var graphQLRequest = new GraphQLRequest()
                {
                    Query = @"
                        mutation CreateCheckOutQuanNh($input: CheckOutQuanNhInput!) {
                            createCheckOutQuanNh(entity: $input)
                        }",
                    Variables = new { input = input }
                };

                var response = await _graphQLClient.SendMutationAsync<CreateCheckOutQuanNhGraphQLResponse>(graphQLRequest);
                var result = response?.Data?.createCheckOutQuanNh ?? 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"GraphQL Error: {ex.Message}", ex);
            }
        }

        public async Task<List<ReturnCondition>> GetReturnConditions()
        {
            try
            {
                var query = @"query ReturnConditions {
                            returnConditions {
                                returnConditionId
                                name
                                severityLevel
                                repairCost
                                isResolved
                                }
                            }
                        ";
                var response = await _graphQLClient.SendQueryAsync<ReturnConditionGraphQLResponse>(query);

                var result = response?.Data?.returnConditions?.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CheckOutQuanNh> GetCheckOutQuanNh(int id)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"query CheckOutQuanNh($id: Int!) {
                                checkOutQuanNh(id: $id) {
                                    checkOutQuanNhid
                                    checkOutTime
                                    returnDate
                                    extraCost
                                    totalCost
                                    lateFee
                                    isPaid
                                    isDamageReported
                                    notes
                                    customerFeedback
                                    paymentMethod
                                    staffSignature
                                    customerSignature
                                    returnConditionId
                                    returnCondition {
                                        returnConditionId
                                        name
                                        severityLevel
                                        repairCost
                                    }
                                }
                            }",
                    Variables = new { id = id }
                };

                var response = await _graphQLClient.SendQueryAsync<CheckOutQuanNhGraphQLResponse>(request);
                var result = response?.Data?.checkOutQuanNh;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"GraphQL Error: {ex.Message}", ex);
            }
        }

        public async Task<int> UpdateCheckOutQuanNh(CheckOutQuanNh entity)
        {
            try
            {
                var input = new
                {
                    checkOutQuanNhid = entity.CheckOutQuanNhid,
                    checkOutTime = entity.CheckOutTime?.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    returnDate = entity.ReturnDate?.ToString("yyyy-MM-dd"),
                    extraCost = entity.ExtraCost,
                    totalCost = entity.TotalCost,
                    lateFee = entity.LateFee,
                    isPaid = entity.IsPaid,
                    isDamageReported = entity.IsDamageReported,
                    notes = entity.Notes,
                    customerFeedback = entity.CustomerFeedback,
                    paymentMethod = entity.PaymentMethod,
                    staffSignature = entity.StaffSignature,
                    customerSignature = entity.CustomerSignature,
                    returnConditionId = entity.ReturnConditionId
                };

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation UpdateCheckOutQuanNh($input: CheckOutQuanNhInput!) {
                            updateCheckOutQuanNh(entity: $input)
                        }",
                    Variables = new { input = input }
                };

                var response = await _graphQLClient.SendMutationAsync<UpdateCheckOutQuanNhGraphQLResponse>(request);
                var result = response?.Data?.updateCheckOutQuanNh ?? 0;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"GraphQL Error: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteCheckOutQuanNh(int id)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation DeleteCheckOutQuanNh($id: Int!) {
                            deleteCheckOutQuanNh(id: $id)
                        }",
                    Variables = new { id = id }
                };

                var response = await _graphQLClient.SendMutationAsync<DeleteCheckOutQuanNhGraphQLResponse>(request);
                var result = response?.Data?.deleteCheckOutQuanNh ?? false;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"GraphQL Error: {ex.Message}", ex);
            }
        }

        public async Task<PaginationResult<List<CheckOutQuanNh>>> GetCheckOutQuanNhsWithPagination(int currentPage, int pageSize)
        {
            try
            {
                var searchRequest = new
                {
                    currentPage = currentPage,
                    pageSize = pageSize,
                    note = (string)null,
                    cost = (decimal?)null,
                    name = (string)null
                };

                var request = new GraphQLRequest
                {
                    Query = @"
                        query SearchWithPagination($request: CheckOutQuanNhSearchRequestInput!) {
                            searchWithPagination(request: $request) {
                                totalItems
                                totalPages
                                currentPage
                                pageSize
                                items {
                                    checkOutQuanNhid
                                    checkOutTime
                                    returnDate
                                    extraCost
                                    totalCost
                                    lateFee
                                    isPaid
                                    isDamageReported
                                    notes
                                    customerFeedback
                                    paymentMethod
                                    staffSignature
                                    customerSignature
                                    returnConditionId
                                    returnCondition {
                                        returnConditionId
                                        name
                                        severityLevel
                                        repairCost
                                    }
                                }
                            }
                        }",
                    Variables = new { request = searchRequest }
                };

                var response = await _graphQLClient.SendQueryAsync<SearchWithPaginationGraphQLResponse>(request);
                var result = response?.Data?.searchWithPagination;

                return result ?? new PaginationResult<List<CheckOutQuanNh>>
                {
                    Items = new List<CheckOutQuanNh>(),
                    CurrentPage = 1,
                    PageSize = pageSize,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"GraphQL Error: {ex.Message}", ex);
            }
        }

        public async Task<PaginationResult<List<CheckOutQuanNh>>> SearchWithPagination(string? note, decimal? cost, string? name, int currentPage, int pageSize)
        {
            try
            {
                // Đảm bảo các giá trị pagination hợp lệ
                if (currentPage < 1) currentPage = 1;
                if (pageSize < 1) pageSize = 10;

                var searchRequest = new
                {
                    currentPage = currentPage,
                    pageSize = pageSize,
                    note = string.IsNullOrWhiteSpace(note) ? null : note,
                    cost = cost,
                    name = string.IsNullOrWhiteSpace(name) ? null : name
                };

                Console.WriteLine($"GraphQL SearchWithPagination request: {System.Text.Json.JsonSerializer.Serialize(searchRequest)}");

                var request = new GraphQLRequest
                {
                    Query = @"
                        query SearchWithPagination($request: CheckOutQuanNhSearchRequestInput!) {
                            searchWithPagination(request: $request) {
                                totalItems
                                totalPages
                                currentPage
                                pageSize
                                items {
                                    checkOutQuanNhid
                                    checkOutTime
                                    returnDate
                                    extraCost
                                    totalCost
                                    lateFee
                                    isPaid
                                    isDamageReported
                                    notes
                                    customerFeedback
                                    paymentMethod
                                    staffSignature
                                    customerSignature
                                    returnConditionId
                                    returnCondition {
                                        returnConditionId
                                        name
                                        severityLevel
                                        repairCost
                                    }
                                }
                            }
                        }",
                    Variables = new { request = searchRequest }
                };

                var response = await _graphQLClient.SendQueryAsync<SearchWithPaginationGraphQLResponse>(request);
                
                Console.WriteLine($"GraphQL response received: HasData={response?.Data != null}, HasErrors={response?.Errors?.Length > 0}");
                
                if (response?.Errors != null && response.Errors.Length > 0)
                {
                    foreach (var error in response.Errors)
                    {
                        Console.WriteLine($"GraphQL Error: {error.Message}");
                    }
                }

                var result = response?.Data?.searchWithPagination;

                if (result == null)
                {
                    Console.WriteLine("SearchWithPagination: result is null, returning empty result");
                    return new PaginationResult<List<CheckOutQuanNh>>
                    {
                        Items = new List<CheckOutQuanNh>(),
                        CurrentPage = currentPage,
                        PageSize = pageSize,
                        TotalItems = 0,
                        TotalPages = 0
                    };
                }

                Console.WriteLine($"SearchWithPagination success: {result.TotalItems} items, {result.TotalPages} pages");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GraphQL SearchWithPagination Error: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                
                return new PaginationResult<List<CheckOutQuanNh>>
                {
                    Items = new List<CheckOutQuanNh>(),
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }
        }

        public async Task<SystemUserAccount> Login(string userName, string password)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                        query Login($userName: String!, $password: String!) {
                            login(userName: $userName, password: $password) {
                                userAccountId
                                userName
                                fullName
                                email
                                phone
                                employeeCode
                                roleId
                                isActive
                            }
                        }",
                    Variables = new { userName = userName, password = password }
                };

                var response = await _graphQLClient.SendQueryAsync<LoginGraphQLResponse>(request);
                
                if (response?.Errors != null && response.Errors.Length > 0)
                {
                    Console.WriteLine($"GraphQL Login Error: {response.Errors[0].Message}");
                    return null;
                }

                return response?.Data?.login;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login Error: {ex.Message}");
                return null;
            }
        }
    }
}
