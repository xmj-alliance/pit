# customize-checkbox

This cog shows an idea of customizing the styles of check boxes and radio buttons in a web page, by editing corresponding css rules.

Implementation:

``` html
<label>
  <input type="checkbox" name="assistant" value="cortana" />
  <div class="card">
    <picture>
      <img src="./assets/images/cortana.png" alt="Cortana">
    </picture>
    <small>Cortana</small>
  </div>
</label>
```

``` scss

input[type="checkbox"],
input[type="radio"]
{
  appearance: none;
  &:checked + .card {
    border-color: $primary;
  }
}

```

## Live Example

You can find a [Live Example](https://codesandbox.io/s/customize-checkbox-rgjz7?fontsize=14&hidenavigation=1&theme=dark) on codesandbox

