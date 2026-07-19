# PCLStar 启动器

<!-- 徽章区域（Stars、Release、Build、Issues、PR、Downloads） -->
<p align="center">
  <a href="https://github.com/PCLStar/PCLStar/stargazers">
    <img src="https://img.shields.io/github/stars/PCLStar/PCLStar?style=flat-square&color=yellow" alt="Stars">
  </a>
  <a href="https://github.com/PCLStar/PCLStar/releases">
    <img src="https://img.shields.io/github/v/release/PCLStar/PCLStar?style=flat-square&color=blue" alt="Release">
  </a>
  <img src="https://img.shields.io/badge/build-passing-brightgreen?style=flat-square" alt="Build Passing">
  <a href="https://github.com/PCLStar/PCLStar/issues">
    <img src="https://img.shields.io/github/issues/PCLStar/PCLStar?style=flat-square&color=red" alt="Issues">
  </a>
  <a href="https://github.com/PCLStar/PCLStar/pulls">
    <img src="https://img.shields.io/github/issues-pr/PCLStar/PCLStar?style=flat-square&color=blueviolet" alt="Pull Requests">
  </a>
  <a href="https://github.com/PCLStar/PCLStar/releases">
    <img src="https://img.shields.io/github/downloads/PCLStar/PCLStar/total?style=flat-square&color=orange" alt="Downloads">
  </a>
</p>

<!-- 荣誉标签 + B站动态（使用 for-the-badge 风格） -->
<p align="center">
  <a href="https://github.com/PCLStar/PCLStar">
    <img src="https://img.shields.io/badge/🏆%20%231%20Repository%20Of%20The%20Week-gold?style=for-the-badge&logo=github" alt="#1 Repository Of The Week">
  </a>
  <a href="https://github.com/PCLStar/PCLStar">
    <img src="https://img.shields.io/badge/⭐%20%232%20Repository%20Of%20The%20Day-silver?style=for-the-badge&logo=github" alt="#2 Repository Of The Day">
  </a>
  <a href="https://space.bilibili.com/your-bilibili-id">
    <img src="https://img.shields.io/badge/动态-Bilibili-00A1D6?style=for-the-badge&logo=bilibili&logoColor=white" alt="Bilibili">
  </a>
</p>

---

[![.NET](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)
[![Stars](https://img.shields.io/github/stars/PCLStar/PCLStar?style=social)](https://github.com/PCLStar/PCLStar)

**PCLStar** 是一款基于 .NET 8 的现代化 Minecraft 启动器，支持多认证、多版本、模组管理以及炫酷的星空主题界面。

---

## ✨ 特性

- **多账户认证**  
  支持 Microsoft（OAuth）、离线登录、LittleSkin 以及自定义 Yggdrasil 服务器。

- **极速下载**  
  集成 BMCLAPI、MCBBS 等国内镜像源，支持并行下载资源文件与库文件。

- **模组/资源包/光影管理**  
  一键安装/卸载 Forge、Fabric、Quilt 等模组加载器，管理资源包和光影包。

- **游戏优化**  
  可自定义内存分配、JVM 参数，支持性能优化选项。

- **星空主题 UI**  
  暗色/亮色主题自由切换，粒子背景动态效果，界面美观流畅。

- **跨平台支持**  
  基于 .NET 8 和 WPF，可在 Windows 10/11 上原生运行（后续可移植到 Avalonia 以实现跨平台）。

---

## 📦 依赖组件

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)（必需）
- 第三方库（通过 NuGet 自动还原）：
  - Newtonsoft.Json (13.0.3)
  - SharpCompress (0.32.2)
  - HtmlAgilityPack (1.11.46)
- 外部工具：
  - `authlib-injector.jar`（用于 Yggdrasil 认证注入，位于 `Libs/` 目录）

---

## 🚀 快速开始

### 编译与运行

1. **克隆仓库**
   ```bash
   git clone https://github.com/PCLStar/PCLStar.git
   cd PCLStar
