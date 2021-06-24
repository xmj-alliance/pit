const { resolve } = require('path');

require('webpack');
const { TsconfigPathsPlugin } = require("tsconfig-paths-webpack-plugin");
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const nodeExternals = require('webpack-node-externals');

const env = process.env.NODE_ENV;
const isDevMode = (env && env.toLowerCase() === "development") || false;

const config = {
  mode: "production",

  entry: {
    "cog": resolve("./src/", "main")
  },

  resolve: {
    extensions: ['.ts', '.js'],
    plugins: [new TsconfigPathsPlugin({})],
  },

  target: "node",

  node: {
    __dirname: false,
    __filename: false
  },

  externals: nodeExternals(),

  devtool: false,

  module: {
    rules: [
      {
        test: /\.ts$/,
        use: "ts-loader",
        exclude:  /node_modules/,
      },
    ]
  },

  plugins: [
    new CleanWebpackPlugin(),
  ],

  output: {
    path: resolve('./dist'),
    publicPath: '/',
    filename: '[name].js',
    chunkFilename: '[id].[hash].chunk.js'
  },

  stats: {
    // Ignore warnings due to yarg's dynamic module loading
    warningsFilter: [/node_modules\/yargs/],
    excludeAssets: [
      /\.json$/,
      /\.jpg$/,
      /\.png$/,
      /\.bmp$/,
      /\.map$/,
      /\.css$/,
      /\.html$/,
      /\.ico$/,
    ]

  },

}

if (isDevMode) {
  config.mode = "development";
  config.devtool = "eval";
}

module.exports = config;