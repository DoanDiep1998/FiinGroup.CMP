namespace StoxPlus.Infrastructure.Const
{
    internal class ScriptConst
    {
        public const string InitCacheLuaScript = @"
            redis.call('DEL', KEYS[1])

            local ttl = tonumber(ARGV[1])
            local i = 2
            local batchSize = 500  -- 250 items mỗi batch

            while i <= #ARGV do
                local args = {}
                for j = 1, batchSize * 2 do
                    if ARGV[i] == nil then break end
                    table.insert(args, ARGV[i])
                    i = i + 1
                end
                redis.call('ZADD', KEYS[1], unpack(args))
            end

            redis.call('EXPIRE', KEYS[1], ttl)
            return 1
            ";
    }
}
