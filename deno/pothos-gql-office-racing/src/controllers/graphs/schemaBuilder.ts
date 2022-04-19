import SchemaBuilder from "@hayes/pothos";

const createSchemaBuilder = () => {
  return new SchemaBuilder({});
};

export { createSchemaBuilder };

export type PothosSchemaBuilder = PothosSchemaTypes.SchemaBuilder<
  PothosSchemaTypes.ExtendDefaultTypes<{}>
>;

export type PothosQueryBuilder = PothosSchemaTypes.QueryFieldBuilder<
  PothosSchemaTypes.ExtendDefaultTypes<{}>,
  {}
>;
