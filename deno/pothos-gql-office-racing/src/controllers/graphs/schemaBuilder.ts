import SchemaBuilder from "@hayes/pothos";

export const createSchemaBuilder = () => {
  return new SchemaBuilder({});
};

export type PothosSchemaBuilder = PothosSchemaTypes.SchemaBuilder<
  PothosSchemaTypes.ExtendDefaultTypes<{}>
>;

export type PothosQueryBuilder = PothosSchemaTypes.QueryFieldBuilder<
  PothosSchemaTypes.ExtendDefaultTypes<{}>,
  {}
>;

export type PothosMutationBuilder = PothosSchemaTypes.MutationFieldBuilder<
  PothosSchemaTypes.ExtendDefaultTypes<{}>,
  {}
>;
