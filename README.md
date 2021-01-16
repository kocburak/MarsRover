# MarsRover

## Usage With Input File

If an argument provided, it will be processed as a file path. Only the first argument will be used, others will be ommited.

```
$ dotnet MarsRover.dll input.txt
1 3 N
5 1 E
```

Content of `input.txt`
```
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```

## Usage With Terminal

İt will wait for input until provided with an empty line. After that, all the provided inputs will be put on action.

```
$ dotnet MarsRover.dll
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

1 3 N
5 1 E
```