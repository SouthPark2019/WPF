### Style概念

提前设置好某一类控件的属性，开箱即用，避免多次书写繁琐的设置属性的代码。

### 方法

Style保存成资源，将目标控件的Style属性设置成该资源。

### 范例

1. 显示应用

```xaml
<Grid>
    <Grid.Resources>
        <Style x:Key="rotateButton">
            <Setter Property="Button.Height" Value="100"/>
            <Setter Property="Button.Width" Value="100"/>
            <Setter Property="Button.Background" Value="AliceBlue"/>
            <Setter Property="Button.RenderTransform">
                <Setter.Value>
                    <RotateTransform Angle="45"/>
                </Setter.Value>
            </Setter>
        </Style>
    </Grid.Resources>
    <Button Style="{StaticResource ResourceKey=rotateButton}"/>
</Grid>

```

2. 自动应用

```xaml
<Grid>
    <Grid.Resources>

        <Style TargetType="{x:Type Button}">
            <Setter Property="Height" Value="100"/>
            <Setter Property="Width" Value="100"/>
            <Setter Property="Background" Value="Brown"/>
            <Setter Property="RenderTransform">
                <Setter.Value>
                    <RotateTransform Angle="45"/>
                </Setter.Value>
            </Setter>
        </Style>
    </Grid.Resources>
	<Button/>
</Grid>
```

### 效果

![image][test_id]

### Style的继承机制

我们为不同类型的控件设置Style，但是这些Style中的属性有共同的部分，这时候我们可以采用继承机制减少代码量。

```xaml
<Grid>
    <Grid.Resources>
        <Style x:Key="controlStyle">
            <Setter Property="Control.Background" Value="Black"/>
        </Style>
        <Style x:Key="buttonStyle" BasedOn="{StaticResource ResourceKey=controlStyle}">
            <Setter Property="Button.Height" Value="100"/>
            <Setter Property="Button.Width" Value="100"/>
        </Style>
    </Grid.Resources>
    <Button Style="{StaticResource ResourceKey=buttonStyle}"/>
</Grid>

```

```xaml
<Grid>
    <Grid.Resources>
        <Style TargetType="{x:Type Control}">
            <Setter Property="Background" Value="Black"/>
        </Style>
        <Style TargetType="{x:Type Button}" BasedOn="{StaticResource {x:Type Control}}">
            <Setter Property="Height" Value="100"/>
            <Setter Property="Width" Value="100"/>
        </Style>
    </Grid.Resources>
    <Button/>
</Grid>

```

### Style补充

每个Style都要有个key属性，如果TargetType被赋值，就会自动应用样式。同时，会自动把key赋值成{x:Type Control}对象。如果我们想使用无key的Style，可以<Button Style = "{StaticResource {x:Type Control}}";





























































[test_id]:data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAJkAAACBCAYAAADT2RhMAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAAQASURBVHhe7dw7ThxBEIdxn4cMiZSMA/A+Ba8UEfFKIEYkjixZ4MCywLyRgCNwFiIkgrZr2NayMCz7qt2uqu+T/sGkPT+NJupviUg5kJF6ICP1QEbqgYzUAxmpBzJSD2SkHshIPZCReiAj9UBG6oGM1AMZqQcyUg9kpB7ISD2QkXogI/VARuqBjNQDGakHMlIPZKQeyEg9kJF6IBtQT09P6fn5ufFEbwPZABJgR3t76fjgAGg1gazPMrBfExPp9+Qk0GoCWR9VwNbX05+pqfRzbKza3+npdLS5CbQ3gazH6oDlnQGtJZD1UDtgeUBrBrIu6wRYHtBeA1kXdQMsD2gg67hegOWdzcyEhgayDuoHWF4FbWsrJDSQfdEggOVFhQayNg0SWF5EaCD7JA1gedGggawmTWB5kaCB7F3DAJZ3NjsbAhrI3jRMYHkRoIGs0SiA5XmHBrL/jRJYnmdo4ZGVACzv3Cm00MhKApZXQdvedgUtLLISgeWdz825ghYSWcnA8jxBC4fMArA8L9BCIbMELM8DtDDILALLsw4tBDLLwPIsQ3OPzAOwvPP5eZPQXCPzBCzPIjS3yDwCy7MGzSUyz8DyKmg7OyaguUMWAVieFWiukEUClne+sFA8NDfIIgLLKx2aC2SRgeWVDM08MoA1d1EoNNPIAPZxJUIziwxgn680aCaRAezrXSwuFgPNHDKAdb4K2u7uyKGZQvby8pK+7+9XlwDXHSr7OLks+cfhYeMER5O5L9nd5WU6WVqqPVDWuuPx8XS2sZEeHx8bpzeaTP6TAe3rlQJMMolMAtrnKwmYZBaZBLSPKw2YZBqZBLTmSgQmmUcmAa1cYJILZFJkaCUDk9wgk+6urtLJ8nLti/C60oFJrpBJ94GgWQAmuUMmRYBmBZjkEpnkGZolYJJbZJJHaNaASa6RSZ6gWQQmuUcmeYBmFZgUAplkGZplYFIYZNL99XU6WVmpfZGlzjowKRQyyRI0D8CkcMgkC9C8AJNCIpNKhuYJmBQWmVQiNG/ApNDIpJKgeQQmhUcmlQDNKzAJZI1GCc0zMAlkb6qgra7WQtCad2ASyN51f3MzNGgRgEkgq2kY0KIAk0D2SZrQIgGTQNYmDWjRgEkg+6JBQosITAJZBw0CWlRgEsg6rB9okYFJIOsigXbaJbTowCSQddn97W06XVurBfV+AHsNZD3UCTSANQNZj7WDBrDWQNZHddAA9jGQ9dnDw0PLbUKny8sAexfIBlCGBrD6QDagBBrA6gMZqQcyUg9kpB7ISD2QkXogI/VARuqBjNQDGakHMlIPZKQeyEg9kJF6ICP1QEbqgYzUAxmpBzJSD2SkHshIPZCReiAj9UBG6oGMlEvpHyN0jMpLF8gtAAAAAElFTkSuQmCC









