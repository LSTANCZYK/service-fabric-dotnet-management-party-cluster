﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace PartyCluster.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PartyCluster.Domain;

    public class MockClusterOperator : IClusterOperator
    {
        public MockClusterOperator()
        {
            this.CreateClusterAsyncFunc = name => Task.FromResult(name);
            this.DeleteClusterAsyncFunc = domain => Task.FromResult(true);
            this.GetClusterPortsAsyncFunc = domain => Task.FromResult(new[] {80, 8081, 405, 520} as IEnumerable<int>);
            this.GetClusterStatusAsyncFunc = domain => Task.FromResult(ClusterOperationStatus.Ready);
        }

        public Func<string, Task<string>> CreateClusterAsyncFunc { get; set; }

        public Func<string, Task> DeleteClusterAsyncFunc { get; set; }

        public Func<string, Task<IEnumerable<int>>> GetClusterPortsAsyncFunc { get; set; }

        public Func<string, Task<ClusterOperationStatus>> GetClusterStatusAsyncFunc { get; set; }

        public Task<string> CreateClusterAsync(string name)
        {
            return this.CreateClusterAsyncFunc(name);
        }

        public Task DeleteClusterAsync(string name)
        {
            return this.DeleteClusterAsyncFunc(name);
        }

        public Task<IEnumerable<int>> GetClusterPortsAsync(string name)
        {
            return this.GetClusterPortsAsyncFunc(name);
        }

        public Task<ClusterOperationStatus> GetClusterStatusAsync(string name)
        {
            return this.GetClusterStatusAsyncFunc(name);
        }
    }
}