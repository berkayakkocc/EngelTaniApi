﻿namespace EngelTaniApi.Application.Dtos
{
    public class PaginationRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int Skip => (Page - 1) * PageSize;
    }
}
