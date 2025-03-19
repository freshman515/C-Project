﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Messages {
    public class ChangeUserMessage : ValueChangedMessage<UserEntity> {
        public ChangeUserMessage(UserEntity value) : base(value) {
        }
    }
}
