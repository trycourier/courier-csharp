using System;
using System.Collections.Generic;
using System.Net.Http;
using TryCourier.Models;
using TryCourier.Models.Lists;
using TryCourier.Models.Lists.Subscriptions;

namespace TryCourier.Tests.Models.Lists.Subscriptions;

public class SubscriptionAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionAddParams
        {
            ListID = "list_id",
            Recipients =
            [
                new()
                {
                    RecipientID = "user_abc",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
                new()
                {
                    RecipientID = "user_def",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        string expectedListID = "list_id";
        List<PutSubscriptionsRecipient> expectedRecipients =
        [
            new()
            {
                RecipientID = "user_abc",
                Preferences = new()
                {
                    Categories = new Dictionary<string, NotificationPreferenceDetails>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = PreferenceStatus.OptedIn,
                                ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                Rules = [new() { Until = "until", Start = "start" }],
                            }
                        },
                    },
                    Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = PreferenceStatus.OptedIn,
                                ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                Rules = [new() { Until = "until", Start = "start" }],
                            }
                        },
                    },
                },
            },
            new()
            {
                RecipientID = "user_def",
                Preferences = new()
                {
                    Categories = new Dictionary<string, NotificationPreferenceDetails>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = PreferenceStatus.OptedIn,
                                ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                Rules = [new() { Until = "until", Start = "start" }],
                            }
                        },
                    },
                    Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = PreferenceStatus.OptedIn,
                                ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                Rules = [new() { Until = "until", Start = "start" }],
                            }
                        },
                    },
                },
            },
        ];
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedListID, parameters.ListID);
        Assert.Equal(expectedRecipients.Count, parameters.Recipients.Count);
        for (int i = 0; i < expectedRecipients.Count; i++)
        {
            Assert.Equal(expectedRecipients[i], parameters.Recipients[i]);
        }
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionAddParams
        {
            ListID = "list_id",
            Recipients =
            [
                new()
                {
                    RecipientID = "user_abc",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
                new()
                {
                    RecipientID = "user_def",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionAddParams
        {
            ListID = "list_id",
            Recipients =
            [
                new()
                {
                    RecipientID = "user_abc",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
                new()
                {
                    RecipientID = "user_def",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionAddParams parameters = new()
        {
            ListID = "list_id",
            Recipients =
            [
                new()
                {
                    RecipientID = "user_abc",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
                new()
                {
                    RecipientID = "user_def",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/lists/list_id/subscriptions"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SubscriptionAddParams parameters = new()
        {
            ListID = "list_id",
            Recipients =
            [
                new()
                {
                    RecipientID = "user_abc",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
                new()
                {
                    RecipientID = "user_def",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["order-ORD-456-user-123"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
        Assert.Equal(["1785312000"], requestMessage.Headers.GetValues("x-idempotency-expiration"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionAddParams
        {
            ListID = "list_id",
            Recipients =
            [
                new()
                {
                    RecipientID = "user_abc",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
                new()
                {
                    RecipientID = "user_def",
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = PreferenceStatus.OptedIn,
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        SubscriptionAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
