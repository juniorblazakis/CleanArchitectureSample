﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureSample.Application.Users.Queries.GetUsersList;
using CleanArchitectureSample.Infrastructure.Database;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using Shouldly;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class GetUsersListQueryHandlerTest : ContextHandleTestBase
    {
        private readonly GetUsersListQueryHandler getUsersListQueryHandler;

        public GetUsersListQueryHandlerTest() : base()
        {
            getUsersListQueryHandler = new GetUsersListQueryHandler(usersContext, mapper);
        }

        [Fact]
        public async Task GetUsersList()
        {
            var result = await getUsersListQueryHandler.Handle(new GetUsersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<GetUsersListViewModel>();
            result.Users.Count.ShouldBe(3);
        }
    }
}
