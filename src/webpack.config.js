const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const {CleanWebpackPlugin} = require('clean-webpack-plugin');

const bundleFileName = 'bundle';
const dirName = 'wwwroot/dist';

module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: ['./node_modules/jquery/dist/jquery.js',
            './node_modules/bootstrap/dist/js/bootstrap.bundle.js',
            './wwwroot/js/site.js',
            './wwwroot/scss/site.scss',
            './node_modules/jquery-validation/dist/jquery.validate.js',
            './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js',
            './node_modules/requirejs/require.js',
            './node_modules/chart.js/dist/chart.js'],
        output: {
            filename: bundleFileName + '.js',
            path: path.resolve(__dirname, dirName)
        },
        module: {
            rules: [
                {
                    parser: {
                        amd: false,
                    },
                    test: /\.s[c|a]ss$/,
                    use:
                        [
                            'style-loader',
                            MiniCssExtractPlugin.loader,
                            'css-loader',
                            {
                                loader: 'postcss-loader', // Run postcss actions
                                options: {
                                    postcssOptions: {
                                        plugins: function () { // postcss plugins, can be exported to postcss.config.js
                                            
                                            let plugins = [require('autoprefixer')];
                                            
                                            if(argv.mode === "production") {
                                                
                                                plugins.push(require('cssnano'));
                                            }
                                            
                                            return plugins;
                                        }
                                    }
                                }
                            },
                            'sass-loader'
                        ]
                }
            ]
        },
        plugins: [
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: bundleFileName + '.css'
            })
        ]
    };
};