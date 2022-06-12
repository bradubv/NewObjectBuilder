// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents the information necessary for registration of a builder policy. A policy is
	/// registered by the interface policy type, the type the policy applies to, and the ID
	/// the policy applies to.
	/// </summary>
	public struct BuilderPolicyKey
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BuilderPolicyKey"/> struct using the
		/// provided policy type, application type, and application ID.
		/// </summary>
		/// <param name="policyType">The policy interface type.</param>
		/// <param name="typePolicyAppliesTo">The type the policy applies to.</param>
		/// <param name="idPolicyAppliesTo">The ID the policy applies to.</param>
		public BuilderPolicyKey(Type policyType, Type typePolicyAppliesTo, string idPolicyAppliesTo)
		{
			PolicyType = policyType;
			BuildType = typePolicyAppliesTo;
			BuildID = idPolicyAppliesTo;
		}

		private Type PolicyType;
		private Type BuildType;
		private string BuildID;
	}
}