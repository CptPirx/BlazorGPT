﻿using Microsoft.SemanticKernel;

namespace BlazorGPT.Pipeline.Interceptors;

public interface IInterceptorHandler
{
    Task<Conversation> Send(Kernel kernel, 
        Conversation conversation,
        IEnumerable<IInterceptor>? enabledInterceptors = null, 
        CancellationToken cancellationToken = default);

    Task<Conversation> Send(Kernel kernel,
        Conversation conversation, 
        IEnumerable<string> enabledInterceptors, 
        CancellationToken cancellationToken = default);

    Task<Conversation> Receive(Kernel kernel,
        Conversation conversation,
        IEnumerable<string> interceptors,
        CancellationToken cancellationToken = default);

    Task<Conversation> Receive(Kernel kernel,
        Conversation conversation,
        IEnumerable<IInterceptor>? enabledInterceptors = null,
        CancellationToken cancellationToken = default);
    Func<Task>? OnUpdate { get; set; }

}