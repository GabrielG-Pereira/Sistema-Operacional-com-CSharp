namespace Sistema_Operacional
{
    public class Html
    {
        public static string GerarTreemapHtml(List<Processo> processos, string titulo)
        {
            string dataSeries = "";
            foreach (var processo in processos)
                dataSeries += $"{{ name: '{processo.Nome}', value: {processo.MemoryUsage} }},";
            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <script src='https://code.highcharts.com/highcharts.js'></script>
                <script src='https://code.highcharts.com/modules/treemap.js'></script>
            </head>
            <body>
                <div id='container' style='width: 100%; height: 100%;'></div>
                <script>
                    Highcharts.chart('container', {{
                        series: [{{
                            type: 'treemap',
                            layoutAlgorithm: 'squarified',
                            data: [{dataSeries}]
                        }}],
                        title: {{
                            text: '{titulo}'
                        }},
                        colorAxis: {{
                            minColor: '#FFFFFF',
                            maxColor: Highcharts.getOptions().colors[0]
                        }}
                    }});
                </script>
            </body>
            </html>";
        }
    }
}
