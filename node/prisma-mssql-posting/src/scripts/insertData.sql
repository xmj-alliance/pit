-- insert users
INSERT INTO [dbo].[User](
    [email],
    [name]
) VALUES
    ('poutine@meat.cmd', 'Poutine'),
    ('angularBiter@byonline.com', 'Angular Biter'),
    ('momBigBang@mm-univers.io', 'Mom Bigbang');

-- insert posts
DECLARE @firstAuthorID int = (SELECT TOP 1 [id] from [dbo].[User]);

INSERT INTO [dbo].[Post](
    [createdAt],
    [updatedAt],
    [title],
    [content],
    [published],
    [authorId]
) VALUES
    (GETDATE(), GETDATE(), N'We need more Sandwitch!', N'Facing an enormous challenge, the food industry nowadays has put itself into a situation where the...', 1, @firstAuthorID),
    (GETDATE(), GETDATE(), N'震惊！猫妈妈抢吃小猫猫粮竟是因为。。。', N'22日，小猫喵喵向本台爆料，妈妈最近的行为十分匪夷所思，总是在碗里出现猫粮后自动闪现到面前，并迅速吃掉。本台记者...', 1, @firstAuthorID),
    (GETDATE(), GETDATE(), N'Une lettre à l''assistant Google', N'Cher L''assistant Google. Tu vas bien ou non, je n''en ai rien à faire. Pourquoi? Tu l''as toujours de...', 1, @firstAuthorID),
    (GETDATE(), GETDATE(), N'How to speed run a game?', N'Loving your favorite game soooo much that you even start to think about speed running? Well, a word of advise...', 1, @firstAuthorID),
    (GETDATE(), GETDATE(), N'10大鞭炮燃放小技巧', N'您是否一直对鞭炮燃放持有浓厚的兴趣？您真的了解鞭炮燃放吗？在这里，小编总结了10大鞭炮燃放小技巧，话不多说，咱们来一起看看吧！...', 1, @firstAuthorID),
    (GETDATE(), GETDATE(), N'Échappée belle sur Lac Dindon', N'C’était la fin de la journée 60 que je me suis finalement décidé de m’installer auprès du Lac Dindon. Je me souviens encore le vent…', 1, @firstAuthorID);
