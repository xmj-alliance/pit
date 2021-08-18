const { resolve } = require("path");
const CopyWebpackPlugin = require('copy-webpack-plugin');

let config = {
  plugins: [
    new CopyWebpackPlugin({
      patterns: [
        {
          from: resolve("./src", "statics"),
          to: "statics",
          globOptions: {
            ignore: [".gitkeep"],
          },
        },
      ]
    })  
  ]
};

module.exports = config;