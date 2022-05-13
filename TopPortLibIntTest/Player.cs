﻿using TopPortLib.Interfaces;
using TopPortLibIntTest.Interfaces;
using TopPortLibIntTest.Request;
using TopPortLibIntTest.Response;

namespace TopPortLibIntTest
{
    class Player : IPlayer
    {
        private readonly ICrowPort _crowPort;
        public Player(ICrowPort crowPort)
        {
            _crowPort = crowPort;
        }
        public async Task<PlayerRsp> Play(PlayerReq req)
        {
            var makeRsp = new Func<byte[], PlayerRsp>(data =>
            {
                if (data.Length > 2)
                {
                    return new PlayerRsp() { Success = true };
                }
                return new PlayerRsp() { Success = false };
            });
            return await _crowPort.RequestAsync(req, makeRsp);
        }
    }
}
