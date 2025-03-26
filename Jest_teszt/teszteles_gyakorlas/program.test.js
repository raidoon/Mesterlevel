const { add, visszaAdSzo } = require('./program');

test('adds 1 + 2 to equal 3', () => {
  expect(add(1, 2)).toBe(3);
});

test('adds 5 + 7 to equal 12', () => {
  expect(add(5, 7)).toBe(12);
});

test('adds 3+8 to equal 11', () => {
    expect(add(3, 8)).toBe(11);
  });

  test('adds 0+0 to equal 0', () => {
    expect(add(0, 0)).toBe(0);
  });

  test('adds -5 + 5 to equal 0', () => {
    expect(add(-5, 5)).toBe(0);
  });

  test('be: Süt a nap,3  ki: nap', () => {
    expect(visszaAdSzo("Süt a nap",3)).toBe("nap");
  });

  test('be: Süt a nap,0  ki: ""', () => {
    expect(visszaAdSzo("Süt a nap",0)).toBe("");
  });

  test('be: Süt a nap,4  ki: ""', () => {
    expect(visszaAdSzo("Süt a nap",4)).toBe("");
  });