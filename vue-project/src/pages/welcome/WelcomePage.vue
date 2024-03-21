<template>
  <div class="welcome-page">
    <el-row :gutter="16">
      <el-col :sm="12" :lg="6">
        <div class="box">
          <div class="box-icon"></div>
          <div class="box-cinfo"></div>
        </div>
      </el-col>
      <el-col :sm="12" :lg="6">
        <div class="box"></div>
      </el-col>
      <el-col :sm="12" :lg="6">
        <div class="box"></div>
      </el-col>
      <el-col :sm="12" :lg="6">
        <div class="box"></div>
      </el-col>
    </el-row>

    <div class="echart-box">
      <div class="echart"></div>
      <div class="data">
        <el-table stripe :border="true" :data="list" style="width: 100%">
          <el-table-column label="序号" width="80">
            <template #default="scope">
              {{ scope.$index + 1 }}
            </template>
          </el-table-column>
          <el-table-column prop="Name" label="分类名称" />
          <el-table-column prop="Count" label="图书数量" />
        </el-table>
      </div>
    </div>
  </div>
</template>
<script setup>
import { ElMessage } from 'element-plus';
import { ref, onMounted, onUnmounted } from 'vue';
import http from '../../http';
// 引入 echarts 核心模块，核心模块提供了 echarts 使用必须要的接口。
import * as echarts from 'echarts/core';
// 引入柱状图图表，图表后缀都为 Chart
import { BarChart } from 'echarts/charts';
// 引入提示框，标题，直角坐标系，数据集，内置数据转换器组件，组件后缀都为 Component
import { TitleComponent, TooltipComponent, GridComponent, DatasetComponent, TransformComponent } from 'echarts/components';
// 标签自动布局、全局过渡动画等特性
import { LabelLayout, UniversalTransition } from 'echarts/features';
// 引入 Canvas 渲染器，注意引入 CanvasRenderer 或者 SVGRenderer 是必须的一步
import { CanvasRenderer } from 'echarts/renderers';

// 注册必须的组件
echarts.use([
  TitleComponent,
  TooltipComponent,
  GridComponent,
  DatasetComponent,
  TransformComponent,
  BarChart,
  LabelLayout,
  UniversalTransition,
  CanvasRenderer,
]);

// state
const list = ref([]);

// methods
// 获取数据
const getData = async () => {
  try {
    list.value = await http.getStatisticData();
    const xData = [];
    const yData = [];
    // 绘制图表
    list.value.forEach((item) => {
      xData.push(item.Name);
      yData.push(item.Count);
    });

    drawEcharts(xData, yData);
  } catch {
    ElMessage.error('error');
  }
};

const drawEcharts = (xData, yData) => {
  // 基于准备好的dom，初始化echarts实例
  var myChart = echarts.init(document.querySelector('.echart'));
  // 绘制图表
  myChart.setOption({
    title: {
      text: '图书分类数量图',
    },
    tooltip: {},
    xAxis: {
      data: xData,
    },
    yAxis: {},
    series: [
      {
        name: '图书数量',
        type: 'bar',
        data: yData,
      },
    ],
  });

  // 监听窗口变化
  window.onresize = () => {
    myChart.resize();
  };
};

onMounted(() => {
  getData();
});

onUnmounted(() => {
  window.onresize = null;
});
</script>
<style scoped lang="less">
.welcome-page {
  padding: 16px;
}
.box {
  height: 100px;
  background-color: #fff;
  margin-bottom: 16px;
  display: flex;
  .box-icon {
    width: 100px;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: #409eff;
    .el-icon {
      color: #fff;
      font-size: 30px;
    }
  }
  .box-info {
    flex: 1;
  }
}

.echart-box {
  margin-top: 16px;
  background-color: #fff;
  min-height: 420px;
  display: flex;
  .echart {
    flex: 1;
  }
  .data {
    width: 400px;
  }
}
</style>
