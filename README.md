# YuzekiPipeline

unity version 2020.3.6f1

pipeline learning

## csrp意义

### -流程概述

顾名思义自定义渲染流程，使用*引擎提供的功能*，预设的算法（光照算法，球谐，bicubic图像差值采样，后处理中的颜色处理），以及一些基本的图形api（mesh绘制，总线数据传输，SetRenderTarget），自己*组装*起整个渲染流程，控制各个相机的绘制，包括物体，天空盒，粒子，ui，后处理

*引擎提供的功能*包括相机裁剪，灯光信息，shadowmap深度图绘制，探针信息，探针烘培，光照阴影ao的烘培等。类似shadowmap unity提供了内置的绘制方法，但也允许用户自定义参数修改

*组装的过程*中可以裁剪选用自己所需的功能，也可以修改正常流程，插入自己的流程，并且一定程度上通过改参数修改内置方法，达到所需的效果，或者进行性能优化

### -脑补的功能举例

比如多相机像素分离，透明阴影，解决后处理和场景内信息交互，控制物体分组渲染效果，控制环境光信息

优化方面除了裁剪功能，选用优化算法，还有特殊的优化，比如多光源优化，自定义烘培信息

### -与传统cb自定义渲染流程比较

比起在正常流程中钩起单相机的几个渲染阶段，并通过cb插入，自定义管线直接对整个渲染流程的改造更为彻底，可以获得几乎所有场景、渲染的信息，灵活性更强，但是复杂度也更高，需要处理更多兼容问题
