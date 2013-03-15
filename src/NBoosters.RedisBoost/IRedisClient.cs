﻿#region Apache Licence, Version 2.0
/*
 Copyright 2013 Andrey Bulygin.

 Licensed under the Apache License, Version 2.0 (the "License"); 
 you may not use this file except in compliance with the License. 
 You may obtain a copy of the License at 

		http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software 
 distributed under the License is distributed on an "AS IS" BASIS, 
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 See the License for the specific language governing permissions 
 and limitations under the License.
 */
#endregion

using System;
using System.Threading.Tasks;
using NBoosters.RedisBoost.Core.Serialization;

namespace NBoosters.RedisBoost
{
	public interface IRedisClient : IDisposable
	{
		IRedisSerializer Serializer { get; }
		string ConnectionString { get; }

		Task DisconnectAsync();

		Task<string> ClientKillAsync(string ip, int port);
		Task<MultiBulk> KeysAsync(string pattern);
		Task<long> DelAsync(string key);
		Task<long> BitOpAsync(BitOpType bitOp, string destKey, params string[] keys);
		Task<long> SetBitAsync(string key, long offset, int value);
		Task<long> GetBitAsync(string key, long offset);
		Task<string> MigrateAsync(string host, int port, string key, int destinationDb, int timeout);
		Task<Bulk> DumpAsync(string key);
		Task<long> MoveAsync(string key, int db);
		Task<RedisResponse> ObjectAsync(Subcommand subcommand, params string[] args);
		Task<RedisResponse> SortAsync(string key, string by = null, long? limitOffset = null,
		                         long? limitCount = null, bool? asc = null, bool alpha = false, string destination = null,
		                         string[] getPatterns = null);
		Task<string> RestoreAsync(string key, int ttlInMilliseconds, byte[] serializedValue);
		Task<long> ExistsAsync(string key);
		Task<long> ExpireAsync(string key, int seconds);
		Task<long> PExpireAsync(string key, int milliseconds);
		Task<long> ExpireAtAsync(string key, DateTime timestamp);
		Task<long> PersistAsync(string key);
		Task<long> PttlAsync(string key);
		Task<long> TtlAsync(string key);
		Task<string> TypeAsync(string key);
		Task<string> RandomKeyAsync();
		Task<string> RenameAsync(string key, string newKey);
		Task<long> RenameNxAsync(string key, string newKey);
		Task<string> FlushDbAsync();
		Task<string> FlushAllAsync();
		Task<string> BgRewriteAofAsync();
		Task<string> BgSaveAsync();
		Task<Bulk> ClientListAsync();
		Task<long> DbSizeAsync();
		Task<RedisResponse> ConfigGetAsync(string parameter);
		Task<string> ConfigSetAsync<T>(string parameter, T value);
		Task<string> ConfigSetAsync(string parameter, byte[] value);
		Task<string> ConfigResetStatAsync();
		Task<Bulk> InfoAsync();
		Task<Bulk> InfoAsync(string section);
		Task<long> LastSaveAsync();
		Task<string> SaveAsync();
		Task<string> ShutDownAsync();
		Task<string> ShutDownAsync(bool save);
		Task<string> SlaveOfAsync(string host, int port);
		Task<MultiBulk> TimeAsync();
		Task<string> AuthAsync(string password);
		Task<Bulk> EchoAsync<T>(T message);
		Task<Bulk> EchoAsync(byte[] message);
		Task<string> PingAsync();
		Task<string> QuitAsync();
		Task<string> SelectAsync(int index);
		Task<long> HSetAsync<TFld,TVal>(string key, TFld field, TVal value);
		Task<long> HSetAsync(string key, byte[] field, byte[] value);
		Task<long> HSetNxAsync<TFld,TVal>(string key, TFld field, TVal value);
		Task<long> HSetNxAsync(string key, byte[] field, byte[] value);
		Task<long> HExistsAsync<TFld>(string key, TFld field);
		Task<long> HExistsAsync(string key, byte[] field);
		Task<long> HDelAsync(string key, params object[] fields);
		Task<long> HDelAsync<TFld>(string key, params TFld[] fields);
		Task<long> HDelAsync(string key, params byte[][] fields);
		Task<Bulk> HGetAsync<TFld>(string key, TFld field);
		Task<Bulk> HGetAsync(string key, byte[] field);
		Task<MultiBulk> HGetAllAsync(string key);
		Task<long> HIncrByAsync<TFld>(string key, TFld field, int increment);
		Task<long> HIncrByAsync(string key, byte[] field, int increment);
		Task<Bulk> HIncrByFloatAsync<TFld>(string key, TFld field, double increment);
		Task<Bulk> HIncrByFloatAsync(string key, byte[] field, double increment);
		Task<MultiBulk> HKeysAsync(string key);
		Task<MultiBulk> HValsAsync(string key);
		Task<long> HLenAsync(string key);
		Task<MultiBulk> HMGetAsync<TFld>(string key, params TFld[] fields);
		Task<MultiBulk> HMGetAsync(string key, params byte[][] fields);
		Task<string> HMSetAsync(string key, params MSetArgs[] args);
		Task<RedisResponse> EvalAsync(string script, string[] keys, params object[] arguments);
		Task<RedisResponse> EvalAsync(string script, string[] keys, params byte[][] arguments);
		Task<RedisResponse> EvalShaAsync(byte[] sha1, string[] keys, params object[] arguments);
		Task<RedisResponse> EvalShaAsync(byte[] sha1, string[] keys, params byte[][] arguments);
		Task<Bulk> ScriptLoadAsync(string script);
		Task<MultiBulk> ScriptExistsAsync(params byte[][] sha1);
		Task<string> ScriptFlushAsync();
		Task<string> ScriptKillAsync();
		Task<long> ZAddAsync<T>(string key, long score, T member);
		Task<long> ZAddAsync(string key, long score, byte[] member);
		Task<long> ZAddAsync<T>(string key, double score, T member);
		Task<long> ZAddAsync(string key, double score, byte[] member);
		Task<long> ZAddAsync(string key, params ZAddArgs[] args);
		Task<long> ZRemAsync<T>(string key, params T[] members);
		Task<long> ZRemAsync(string key, params object[] members);
		Task<long> ZRemAsync(string key, params byte[][] members);
		Task<long> ZRemRangeByRankAsync(string key, long start, long stop);
		Task<long> ZRemRangeByScoreAsync(string key, long min, long max);
		Task<long> ZRemRangeByScoreAsync(string key, double min, double max);
		Task<long> ZCardAsync(string key);
		Task<long> ZCountAsync(string key, long min, long max);
		Task<long> ZCountAsync(string key, double min, double max);
		Task<double> ZIncrByAsync<T>(string key, long increment, T member);
		Task<double> ZIncrByAsync(string key, long increment, byte[] member);
		Task<double> ZIncrByAsync<T>(string key, double increment, T member);
		Task<double> ZIncrByAsync(string key, double increment, byte[] member);
		Task<long> ZInterStoreAsync(string destinationKey, params string[] keys);
		Task<long> ZInterStoreAsync(string destinationKey, Aggregation aggregation, params string[] keys);
		Task<long> ZInterStoreAsync(string destinationKey, params ZAggrStoreArgs[] keys);
		Task<long> ZInterStoreAsync(string destinationKey, Aggregation aggregation, params ZAggrStoreArgs[] keys);
		Task<MultiBulk> ZRangeAsync(string key, long start, long stop, bool withScores = false);
		Task<MultiBulk> ZRangeByScoreAsync(string key, long min, long max, bool withScores = false);
		Task<MultiBulk> ZRangeByScoreAsync(string key, long min, long max, long limitOffset, long limitCount, bool withScores = false);
		Task<MultiBulk> ZRangeByScoreAsync(string key, double min, double max, bool withScores = false);
		Task<MultiBulk> ZRangeByScoreAsync(string key, double min, double max, long limitOffset, long limitCount, bool withScores = false);
		Task<long?> ZRankAsync<T>(string key, T member);
		Task<long?> ZRankAsync(string key, byte[] member);
		Task<long?> ZRevRankAsync<T>(string key, T member);
		Task<long?> ZRevRankAsync(string key, byte[] member);
		Task<MultiBulk> ZRevRangeAsync(string key, long start, long stop, bool withscores = false);
		Task<MultiBulk> ZRevRangeByScoreAsync(string key, long min, long max, bool withScores = false);
		Task<MultiBulk> ZRevRangeByScoreAsync(string key, long min, long max, long limitOffset, long limitCount, bool withScores = false);
		Task<MultiBulk> ZRevRangeByScoreAsync(string key, double min, double max, bool withScores = false);
		Task<MultiBulk> ZRevRangeByScoreAsync(string key, double min, double max, long limitOffset, long limitCount, bool withScores = false);
		Task<double> ZScoreAsync<T>(string key, T member);
		Task<double> ZScoreAsync(string key, byte[] member);
		Task<long> ZUnionStoreAsync(string destinationKey, params string[] keys);
		Task<long> ZUnionStoreAsync(string destinationKey, Aggregation aggregation, params string[] keys);
		Task<long> ZUnionStoreAsync(string destinationKey, params ZAggrStoreArgs[] keys);
		Task<long> ZUnionStoreAsync(string destinationKey, Aggregation aggregation, params ZAggrStoreArgs[] keys);
		Task<Bulk> GetAsync(string key);
		Task<string> SetAsync<T>(string key, T value);
		Task<string> SetAsync(string key, byte[] value);
		Task<long> AppendAsync<T>(string key, T value);
		Task<long> AppendAsync(string key, byte[] value);
		Task<long> BitCountAsync(string key);
		Task<long> BitCountAsync(string key, int start, int end);
		Task<long> DecrAsync(string key);
		Task<long> IncrAsync(string key);
		Task<long> DecrByAsync(string key, int decrement);
		Task<long> IncrByAsync(string key, int increment);
		Task<Bulk> IncrByFloatAsync(string key, double increment);
		Task<Bulk> GetRangeAsync(string key, int start, int end);
		Task<long> SetRangeAsync<T>(string key, int offset, T value);
		Task<long> SetRangeAsync(string key, int offset, byte[] value);
		Task<long> StrLenAsync(string key);
		Task<Bulk> GetSetAsync<T>(string key, T value);
		Task<Bulk> GetSetAsync(string key, byte[] value);
		Task<MultiBulk> MGetAsync(params string[] keys);
		Task<string> MSetAsync(params MSetArgs[] args);
		Task<long> MSetNxAsync(params MSetArgs[] args);
		Task<string> SetExAsync<T>(string key, int seconds, T value);
		Task<string> SetExAsync(string key, int seconds, byte[] value);
		Task<string> PSetExAsync<T>(string key, int milliseconds, T value);
		Task<string> PSetExAsync(string key, int milliseconds, byte[] value);
		Task<long> SetNxAsync<T>(string key, T value);
		Task<long> SetNxAsync(string key, byte[] value);
		Task<long> SAddAsync(string key, params object[] members);
		Task<long> SAddAsync<T>(string key, params T[] members);
		Task<long> SAddAsync(string key, params byte[][] members);
		Task<long> SRemAsync(string key, params object[] members);
		Task<long> SRemAsync<T>(string key, params T[] members);
		Task<long> SRemAsync(string key, params byte[][] members);
		Task<long> SCardAsync(string key);
		Task<MultiBulk> SDiffAsync(params string[] keys);
		Task<long> SDiffStoreAsync(string destinationKey, params string[] keys);
		Task<MultiBulk> SUnionAsync(params string[] keys);
		Task<long> SUnionStoreAsync(string destinationKey, params string[] keys);
		Task<MultiBulk> SInterAsync(params string[] keys);
		Task<long> SInterStoreAsync(string destinationKey, params string[] keys);
		Task<long> SIsMemberAsync<T>(string key, T value);
		Task<long> SIsMemberAsync(string key, byte[] value);
		Task<MultiBulk> SMembersAsync(string key);
		Task<long> SMoveAsync<T>(string sourceKey, string destinationKey, T member);
		Task<long> SMoveAsync(string sourceKey, string destinationKey, byte[] member);
		Task<Bulk> SPopAsync(string key);
		Task<Bulk> SRandMemberAsync(string key);
		Task<MultiBulk> SRandMemberAsync(string key, int count);
		Task<MultiBulk> BlPopAsync(int timeoutInSeconds, params string[] keys);
		Task<long> LPushAsync(string key, params object[] values);
		Task<long> LPushAsync<T>(string key, params T[] values);
		Task<long> LPushAsync(string key, params byte[][] values);
		Task<MultiBulk> BrPopAsync(int timeoutInSeconds, params string[] keys);
		Task<long> RPushAsync(string key, params object[] values);
		Task<long> RPushAsync<T>(string key, params T[] values);
		Task<long> RPushAsync(string key, params byte[][] values);
		Task<Bulk> LPopAsync(string key);
		Task<Bulk> RPopAsync(string key);
		Task<Bulk> RPopLPushAsync(string source, string destination);
		Task<Bulk> BRPopLPushAsync(string sourceKey, string destinationKey, int timeoutInSeconds);
		Task<Bulk> LIndexAsync(string key, int index);
		Task<long> LInsertAsync<TPivot,TValue>(string key, TPivot pivot, TValue value, bool before = true);
		Task<long> LInsertAsync(string key, byte[] pivot, byte[] value, bool before = true);
		Task<long> LLenAsync(string key);
		Task<long> LPushXAsync<T>(string key, T value);
		Task<long> LPushXAsync(string key, byte[] value);
		Task<MultiBulk> LRangeAsync(string key, int start, int stop);
		Task<long> LRemAsync<T>(string key, int count, T value);
		Task<long> LRemAsync(string key, int count, byte[] value);
		Task<string> LSetAsync<T>(string key, int index, T value);
		Task<string> LSetAsync(string key, int index, byte[] value);
		Task<string> LTrimAsync(string key, int start, int stop);
		Task<long> RPushXAsync<T>(string key, T values);
		Task<long> RPushXAsync(string key, byte[] values);
		Task<string> DiscardAsync();
		Task<MultiBulk> ExecAsync();
		Task<string> MultiAsync();
		Task<string> UnwatchAsync();
		Task<string> WatchAsync(params string[] keys);
		Task<long> PublishAsync<T>(string channel, T message);
		Task<long> PublishAsync(string channel, byte[] message);

		Task<IRedisSubscription> SubscribeAsync(params string[] channels);
		Task<IRedisSubscription> PSubscribeAsync(params string[] pattern);

	}
}
