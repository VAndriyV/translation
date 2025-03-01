﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Moq;

using StandardRepository.Models;
using StandardRepository.Models.Entities;
using Translation.Data.Entities.Main;
using Translation.Data.Repositories.Contracts;
using static Translation.Common.Tests.TestHelpers.FakeConstantTestHelper;
using static Translation.Common.Tests.TestHelpers.FakeEntityTestHelper;

namespace Translation.Common.Tests.SetupHelpers
{
    public static class IntegrationRepositorySetupHelper
    {
        public static void Setup_Select_Returns_OrganizationOneIntegrationOneNotExist(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Select(It.IsAny<Expression<Func<Integration, bool>>>(), false))
                      .ReturnsAsync(GetIntegrationNotExist);
        }

        public static void Setup_SelectMany_Returns_Integrations(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectMany(It.IsAny<Expression<Func<Integration, bool>>>(),
                                               It.IsAny<int>(),
                                               It.IsAny<int>(),
                                               It.IsAny<bool>(), 
                                               It.IsAny<List<OrderByInfo<Integration>>>()))
                     .ReturnsAsync(new List<Integration> { GetIntegration() });
        }

        public static void Verify_SelectMany(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.SelectMany(It.IsAny<Expression<Func<Integration, bool>>>(),
                                                It.IsAny<int>(),
                                                It.IsAny<int>(),
                                                It.IsAny<bool>(),
                                                It.IsAny<List<OrderByInfo<Integration>>>()));
        }

        public static void Setup_Count_Returns_Ten(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Count(It.IsAny<Expression<Func<Integration, bool>>>(),
                                          It.IsAny<bool>(),
                                          It.IsAny<List<DistinctInfo<Integration>>>()))
                      .ReturnsAsync(Ten);
        }

        public static void Verify_Count(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.Count(It.IsAny<Expression<Func<Integration, bool>>>(),
                                           It.IsAny<bool>(),
                                           It.IsAny<List<DistinctInfo<Integration>>>()));
        }

        public static void Setup_SelectAfter_Returns_Integrations(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectAfter(It.IsAny<Expression<Func<Integration, bool>>>(),
                                                It.IsAny<Guid>(),
                                                It.IsAny<int>(),
                                                It.IsAny<bool>(),
                                                It.IsAny<List<OrderByInfo<Integration>>>()))
                      .ReturnsAsync(new List<Integration> { GetIntegration() });
        }

        public static void Setup_RestoreRevision_Returns_True(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.RestoreRevision(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<int>()))
                      .ReturnsAsync(true);
        }

        public static void Setup_RestoreRevision_Returns_False(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.RestoreRevision(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<int>()))
                .ReturnsAsync(false);
        }

        public static void Verify_RestoreRevision(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.RestoreRevision(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<int>()));
        }

        public static void Setup_SelectRevisions_Returns_InvalidRevision(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectRevisions(It.IsAny<long>()))
                .ReturnsAsync(new List<EntityRevision<Integration>>());
        }

        public static void Setup_SelectRevisions_Returns_RevisionTwo(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectRevisions(It.IsAny<long>()))
                .ReturnsAsync(new List<EntityRevision<Integration>>() { GetIntegrationRevisionTwo() });
        }

        public static void Setup_Delete_Failed(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Delete(It.IsAny<long>(),
                    It.IsAny<long>()))
                .ReturnsAsync(false);
        }

        public static void Setup_Delete_Success(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Delete(It.IsAny<long>(),
                    It.IsAny<long>()))
                .ReturnsAsync(true);
        }

        public static void Setup_Any_Returns_True(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Any(It.IsAny<Expression<Func<Integration, bool>>>(), false))
                .ReturnsAsync(true);
        }

        public static void Setup_Any_Returns_False(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Any(It.IsAny<Expression<Func<Integration, bool>>>(), false))
                .ReturnsAsync(false);
        }

        public static void Setup_Update_Returns_True(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Update(It.IsAny<long>(),
                    It.IsAny<Integration>()))
                .ReturnsAsync(true);
        }

        public static void Setup_Update_Returns_False(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<Integration>()))
                .ReturnsAsync(false);
        }

        public static void Setup_Update_Success(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<Integration>()))
                .ReturnsAsync(true);
        }

        public static void Setup_Update_Failed(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Update(It.IsAny<long>(), It.IsAny<Integration>()))
                .ReturnsAsync(false);
        }

        public static void Setup_Select_Returns_InvalidIntegration(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Select(It.IsAny<Expression<Func<Integration, bool>>>(), false))
                .ReturnsAsync(new Integration());
        }

        public static void Setup_Select_Returns_OrganizationOneIntegrationOne(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Select(It.IsAny<Expression<Func<Integration, bool>>>(), false))
                .ReturnsAsync(GetOrganizationOneIntegrationOne());
        }

        public static void Setup_SelectById_Returns_OrganizationOneIntegrationOneNotExist(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectById(It.IsAny<long>()))
                .ReturnsAsync(GetOrganizationOneIntegrationOneNotExist());
        }

        public static void Setup_SelectById_Returns_OrganizationOneIntegrationOneNotActive(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectById(It.IsAny<long>()))
                .ReturnsAsync(GetOrganizationOneIntegrationOneNotActive());
        }

        public static void Setup_SelectRevisions_Returns_OrganizationOneIntegrationOneRevisions(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectRevisions(It.IsAny<long>()))
                .ReturnsAsync(GetOrganizationOneIntegrationOneRevisions());
        }

        public static void Verify_SelectRevisions(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.SelectRevisions(It.IsAny<long>()));
        }

        public static void Verify_SelectAfter(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.SelectAfter(It.IsAny<Expression<Func<Integration, bool>>>(),
                                                 It.IsAny<Guid>(),
                                                 It.IsAny<int>(),
                                                 It.IsAny<bool>(),
                                                 It.IsAny<List<OrderByInfo<Integration>>>()));
        }

        public static void Verify_Update(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.Update(It.IsAny<long>(),
                                            It.IsAny<Integration>()));
        }

        public static void Setup_Delete_Returns_True(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Delete(It.IsAny<long>(),
                                           It.IsAny<long>()))
                      .ReturnsAsync(true);
        }

        public static void Setup_Delete_Returns_False(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Delete(It.IsAny<long>(),
                                           It.IsAny<long>()))
                      .ReturnsAsync(false);
        }

        public static void Verify_Delete(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.Delete(It.IsAny<long>(),
                                            It.IsAny<long>()));
        }

        public static void Setup_SelectById_Returns_OrganizationOneIntegrationOne(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectById(It.IsAny<long>()))
                      .ReturnsAsync(GetOrganizationOneIntegrationOne());
        }

        public static void Setup_SelectById_Returns_OrganizationTwoIntegrationOne(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.SelectById(It.IsAny<long>()))
                      .ReturnsAsync(GetOrganizationTwoIntegrationOne());
        }

        public static void Verify_SelectById(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.SelectById(It.IsAny<long>()));
        }

        public static void Setup_Select_Returns_OrganizationTwoIntegrationOne(this Mock<IIntegrationRepository> repository)
        {
            repository.Setup(x => x.Select(It.IsAny<Expression<Func<Integration, bool>>>(), false))
                      .ReturnsAsync(GetOrganizationTwoIntegrationOne);
        }

        public static void Verify_Select(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.Select(It.IsAny<Expression<Func<Integration, bool>>>(), false));
        }

        public static void Verify_Any(this Mock<IIntegrationRepository> repository)
        {
            repository.Verify(x => x.Any(It.IsAny<Expression<Func<Integration, bool>>>(), false));
        }
    }
}