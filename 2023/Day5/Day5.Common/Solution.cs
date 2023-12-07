namespace Day5.Common;

public static class Solution
{
    class Map
    {
        public long DestinationStart { get; set; }
        public long SourceStart { get; set; }
        public long RangeLength { get; set; }

        public Map(long destinationStart, long sourceStart, long rangeLength)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            RangeLength = rangeLength;
        }

        public bool Contains(long source)
        {
            return source >= SourceStart && source < SourceStart + RangeLength;
        }

        public long MapToDestination(long source)
        {
            return DestinationStart + (source - SourceStart);
        }
    }

    public static long PartOne(string input)
    {
        List<long> seeds = new();
        List<Map> seedToSoilMaps = new();
        List<Map> soilToFertilizerMaps = new();
        List<Map> fertilizerToWaterMaps = new();
        List<Map> waterToLightMaps = new();
        List<Map> lightToTemperatureMaps = new();
        List<Map> temperatureToHumidityMaps = new();
        List<Map> humidityToLocationMaps = new();

        var lines = input.Split(Environment.NewLine).Where(line => line.Length > 0);
        var state = 0;

        foreach (var line in lines)
        {
            if (line.Contains("seeds: "))
            {
                seeds = line[7..].Split(" ").Select(str => long.Parse(str)).ToList();
            }

            if (line.Contains("seed-to-soil"))
            {
                state = 1;
                continue;
            }
            else if (line.Contains("soil-to-fertilizer"))
            {
                state = 2;
                continue;
            }
            else if (line.Contains("fertilizer-to-water"))
            {
                state = 3;
                continue;
            }
            else if (line.Contains("water-to-light"))
            {
                state = 4;
                continue;
            }
            else if (line.Contains("light-to-temperature"))
            {
                state = 5;
                continue;
            }
            else if (line.Contains("temperature-to-humidity"))
            {
                state = 6;
                continue;
            }
            else if (line.Contains("humidity-to-location"))
            {
                state = 7;
                continue;
            }

            if (state == 1)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                seedToSoilMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 2)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                soilToFertilizerMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 3)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                fertilizerToWaterMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 4)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                waterToLightMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 5)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                lightToTemperatureMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 6)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                temperatureToHumidityMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 7)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                humidityToLocationMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
        }

        var locations = new List<long>();
        foreach (var seed in seeds)
        {
            long soil = -1;
            foreach (var seedToSoilMap in seedToSoilMaps)
            {
                if (seedToSoilMap.Contains(seed))
                {
                    soil = seedToSoilMap.MapToDestination(seed);
                    break;
                }
            }
            soil = soil == -1 ? seed : soil;

            long fertilizer = -1;
            foreach (var soilToFertilizerMap in soilToFertilizerMaps)
            {
                if (soilToFertilizerMap.Contains(soil))
                {
                    fertilizer = soilToFertilizerMap.MapToDestination(soil);
                    break;
                }
            }
            fertilizer = fertilizer == -1 ? soil : fertilizer;

            long water = -1;
            foreach (var fertilizerToWaterMap in fertilizerToWaterMaps)
            {
                if (fertilizerToWaterMap.Contains(fertilizer))
                {
                    water = fertilizerToWaterMap.MapToDestination(fertilizer);
                    break;
                }
            }
            water = water == -1 ? fertilizer : water;

            long light = -1;
            foreach (var waterToLightMap in waterToLightMaps)
            {
                if (waterToLightMap.Contains(water))
                {
                    light = waterToLightMap.MapToDestination(water);
                    break;
                }
            }
            light = light == -1 ? water : light;

            long temperature = -1;
            foreach (var lightToTemperatureMap in lightToTemperatureMaps)
            {
                if (lightToTemperatureMap.Contains(light))
                {
                    temperature = lightToTemperatureMap.MapToDestination(light);
                    break;
                }
            }
            temperature = temperature == -1 ? light : temperature;

            long humidity = -1;
            foreach (var temperatureToHumidityMap in temperatureToHumidityMaps)
            {
                if (temperatureToHumidityMap.Contains(temperature))
                {
                    humidity = temperatureToHumidityMap.MapToDestination(temperature);
                    break;
                }
            }
            humidity = humidity == -1 ? temperature : humidity;

            long location = -1;
            foreach (var humidityToLocationMap in humidityToLocationMaps)
            {
                if (humidityToLocationMap.Contains(humidity))
                {
                    location = humidityToLocationMap.MapToDestination(humidity);
                    break;
                }
            }
            location = location == -1 ? humidity : location;

            locations.Add(location);
        }

        return locations.Min();
    }

    public static long PartTwo(string input)
    {
        List<long> seeds = new();
        List<Map> seedToSoilMaps = new();
        List<Map> soilToFertilizerMaps = new();
        List<Map> fertilizerToWaterMaps = new();
        List<Map> waterToLightMaps = new();
        List<Map> lightToTemperatureMaps = new();
        List<Map> temperatureToHumidityMaps = new();
        List<Map> humidityToLocationMaps = new();

        var lines = input.Split(Environment.NewLine).Where(line => line.Length > 0);
        var state = 0;

        foreach (var line in lines)
        {
            if (line.Contains("seeds: "))
            {
                var seedsRanges = line[7..].Split(" ").Select(str => long.Parse(str)).ToList();
                for (int i = 0; i <= seedsRanges.Count() - 1; i+=2)
                {
                    for(int j = 0; j <= seedsRanges[i + 1]; ++j){
                        seeds.Add(seedsRanges[i] + j);
                    }
                }
                continue;
            }

            if (line.Contains("seed-to-soil"))
            {
                state = 1;
                continue;
            }
            else if (line.Contains("soil-to-fertilizer"))
            {
                state = 2;
                continue;
            }
            else if (line.Contains("fertilizer-to-water"))
            {
                state = 3;
                continue;
            }
            else if (line.Contains("water-to-light"))
            {
                state = 4;
                continue;
            }
            else if (line.Contains("light-to-temperature"))
            {
                state = 5;
                continue;
            }
            else if (line.Contains("temperature-to-humidity"))
            {
                state = 6;
                continue;
            }
            else if (line.Contains("humidity-to-location"))
            {
                state = 7;
                continue;
            }

            if (state == 1)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                seedToSoilMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 2)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                soilToFertilizerMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 3)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                fertilizerToWaterMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 4)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                waterToLightMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 5)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                lightToTemperatureMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 6)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                temperatureToHumidityMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
            else if (state == 7)
            {
                var inputs = line.Split(" ")
                    .Where(str => str.Length > 0)
                    .Select(str => long.Parse(str));

                var destinationStart = inputs.First();
                var sourceStart = inputs.Skip(1).First();
                var rangeLength = inputs.Skip(2).First();

                humidityToLocationMaps.Add(new(destinationStart, sourceStart, rangeLength));
            }
        }

        var locations = new List<long>(seeds.Count());
        foreach (var seed in seeds)
        {
            long soil = -1;
            foreach (var seedToSoilMap in seedToSoilMaps)
            {
                if (seedToSoilMap.Contains(seed))
                {
                    soil = seedToSoilMap.MapToDestination(seed);
                    break;
                }
            }
            soil = soil == -1 ? seed : soil;

            long fertilizer = -1;
            foreach (var soilToFertilizerMap in soilToFertilizerMaps)
            {
                if (soilToFertilizerMap.Contains(soil))
                {
                    fertilizer = soilToFertilizerMap.MapToDestination(soil);
                    break;
                }
            }
            fertilizer = fertilizer == -1 ? soil : fertilizer;

            long water = -1;
            foreach (var fertilizerToWaterMap in fertilizerToWaterMaps)
            {
                if (fertilizerToWaterMap.Contains(fertilizer))
                {
                    water = fertilizerToWaterMap.MapToDestination(fertilizer);
                    break;
                }
            }
            water = water == -1 ? fertilizer : water;

            long light = -1;
            foreach (var waterToLightMap in waterToLightMaps)
            {
                if (waterToLightMap.Contains(water))
                {
                    light = waterToLightMap.MapToDestination(water);
                    break;
                }
            }
            light = light == -1 ? water : light;

            long temperature = -1;
            foreach (var lightToTemperatureMap in lightToTemperatureMaps)
            {
                if (lightToTemperatureMap.Contains(light))
                {
                    temperature = lightToTemperatureMap.MapToDestination(light);
                    break;
                }
            }
            temperature = temperature == -1 ? light : temperature;

            long humidity = -1;
            foreach (var temperatureToHumidityMap in temperatureToHumidityMaps)
            {
                if (temperatureToHumidityMap.Contains(temperature))
                {
                    humidity = temperatureToHumidityMap.MapToDestination(temperature);
                    break;
                }
            }
            humidity = humidity == -1 ? temperature : humidity;

            long location = -1;
            foreach (var humidityToLocationMap in humidityToLocationMaps)
            {
                if (humidityToLocationMap.Contains(humidity))
                {
                    location = humidityToLocationMap.MapToDestination(humidity);
                    break;
                }
            }
            location = location == -1 ? humidity : location;

            locations.Add(location);
        }

        return locations.Min();
    }
}
