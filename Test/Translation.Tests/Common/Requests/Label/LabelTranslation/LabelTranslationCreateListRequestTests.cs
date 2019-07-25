﻿using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;
using Shouldly;

using Translation.Common.Models.Requests.Label.LabelTranslation;
using static Translation.Tests.TestHelpers.FakeRequestTestHelper;
using static Translation.Tests.TestHelpers.FakeConstantTestHelper;
using static Translation.Tests.TestHelpers.FakeEntityTestHelper;

namespace Translation.Tests.Common.Requests.Label.LabelTranslation
{
    public class LabelTranslationCreateListRequestTests
    {

        [Test]
        public void LabelTranslationCreateListRequest_Constructor()
        {
            var labels = GetTranslationListInfoList();
            var request = GetLabelTranslationCreateListRequest(CurrentUserId,UidOne,UidOne,labels);

            request.CurrentUserId.ShouldBe(CurrentUserId);
            request.OrganizationUid.ShouldBe(UidOne);
            request.LabelUid.ShouldBe(UidOne);
            request.LabelTranslations.ShouldBe(labels);
        }

        public static IEnumerable ArgumentTestCases
        {
            get
            {
                yield return new TestCaseData(CurrentUserId, EmptyUid, UidOne, GetTranslationListInfoList());
                yield return new TestCaseData(CurrentUserId, UidOne, EmptyUid, GetTranslationListInfoList());
            }
        }

        [TestCaseSource(nameof(ArgumentTestCases))]
        public void LabelTranslationCreateListRequest_Argument_Validations(long currentUserId, Guid organizationUid, Guid labelUid,
            List<TranslationListInfo> labelTranslations)
        {
            Assert.Throws<ArgumentException>(() => { new LabelTranslationCreateListRequest(currentUserId, organizationUid, labelUid, labelTranslations); });
        }
    }
}