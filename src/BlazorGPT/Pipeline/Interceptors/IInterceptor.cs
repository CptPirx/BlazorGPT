﻿using Microsoft.SemanticKernel;

namespace BlazorGPT.Pipeline.Interceptors;

public interface IInterceptor
{
    string Name { get; }
    bool Internal { get; }
    Task<Conversation> Receive(Kernel kernel, Conversation conversation, CancellationToken cancellationToken = default);
    Task<Conversation> Send(Kernel kernel, Conversation conversation, CancellationToken cancellationToken = default);


}