using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using Masuit.Tools;
using MaterialDesignThemes.Wpf;
using ScadaSystem.Helper.Dtos;
using ScadaSystem.Manager;
using ScadaSystem.Models;
using ScadaSystem.Services;
using ScadaSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScadaSystem.ViewModels {
    internal partial class UserViewModel : ObservableObject, IInjectable {
        public UserManager UserManager { get; }
        public UserSession UserSession { get; }

        public UserViewModel(UserManager userManager, UserSession userSession) {
            UserManager = userManager;
            UserSession = userSession;
        }

        [ObservableProperty]
        private List<UserEntity> userList;

        [RelayCommand]
        void Load() {
            Search();
        }

        [RelayCommand]
        async void Search() {
            var res = await UserManager.GetUserListAsync();
            if (res.Status) {
                UserList = res.Data.Adapt<List<UserEntity>>();
            }

        }

        [RelayCommand]
        async void Add() {
            //判断用户权限
            if (UserSession.CurrentUser.Role != 0) {
                MessageBox.Show("当前用户不是管理员，没有添加用户权限!");
                return;
            }
            var Entity = new UserEntity();
            var view = new UserOperateView { DataContext = new UpdateViewModel<UserEntity>(Entity) };
            var res = (bool)await DialogHost.Show(view, "ShellDialog");
            if (res) {
                //插入用户
                if (Entity.Role > 1) {
                    MessageBox.Show("输入权限有误", "错误");
                    return;
                }
                var dto = Entity.Adapt<UserAddDto>();
                var resAdd = await UserManager.AddUserAsync(dto);
                if (resAdd.Status) {
                    Search();
                    MessageBox.Show("添加成功");
                } else {
                    MessageBox.Show(resAdd.Message);
                }
            }
            //    var res = await UserManager.AddUserAsync(new UserAddDto() { Username = "xmf", Password = "123", Role = 1 });
        }
        [RelayCommand]
        async void Delete(UserEntity userEntity) {
            if (UserSession.CurrentUser.Role != 0) {
                MessageBox.Show("当前用户不是管理员，没有删除用户权限!");
                return;
            }
            if (UserSession.CurrentUser.Username == userEntity.Username) {
                MessageBox.Show("不能删除自己!");
                return;
            }
            if (MessageBox.Show( $"确认删除{userEntity.Username}吗", "提醒",MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                var res = await UserManager.DeleteUserAsync(userEntity.Adapt<UserDeleteDto>());
                if (res.Status) {
                    MessageBox.Show("删除成功");
                    Search();
                } else {
                    MessageBox.Show(res.Message);
                }
            }
        }
        [RelayCommand]
        async void Modify(UserEntity userEntity) {
            if (UserSession.CurrentUser.Role != 0) {
                MessageBox.Show("当前用户不是管理员，没有修改用户权限!");
                return;
            }
            var userClone = userEntity.DeepClone();
            var view = new UserOperateView() { DataContext = new UpdateViewModel<UserEntity>(userClone) };
            var result = (bool)await DialogHost.Show(view, "ShellDialog");
            if (result) {
                userEntity = userClone.Adapt<UserEntity>();
                var res = await UserManager.UpdateUserAsync(userEntity.Adapt<UserUpdateDto>());
                if (res.Status) {
                    MessageBox.Show("修改成功");
                    Search();
                } else {
                    MessageBox.Show(res.Message);
                }
            }
        }
    }
}
