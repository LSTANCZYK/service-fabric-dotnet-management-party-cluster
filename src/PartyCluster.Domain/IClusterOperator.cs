﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace PartyCluster.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClusterOperator
    {
        /// <summary>
        /// Initiates creation of a new cluster.
        /// </summary>
        /// <remarks>
        /// If a cluster with the given domain could not be created, an exception should be thrown indicating the failure reason.
        /// </remarks>
        /// <param name="name">A unique name for the cluster.</param>
        /// <returns>The FQDN of the new cluster.</returns>
        Task<string> CreateClusterAsync(string name);

        /// <summary>
        /// Initiates deletion of a cluster.
        /// </summary>
        /// <remarks>
        /// If the cluster could not be delted, an exception should be thrown indicating the failure reason.
        /// </remarks>
        /// <param name="domain"></param>
        /// <returns></returns>
        Task DeleteClusterAsync(string name);

        /// <summary>
        /// Gets the status of a cluster. If the cluster does not a exist, an exception should be thrown.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        Task<ClusterOperationStatus> GetClusterStatusAsync(string name);

        /// <summary>
        /// Gets a list of input ports available on the cluster.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetClusterPortsAsync(string name);
    }
}